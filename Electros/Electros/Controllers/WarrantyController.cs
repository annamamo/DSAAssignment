using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;
using Electros.BarCodeServ;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;


namespace Electros.Controllers
{
    public class WarrantyController : Controller
    {
        //
        // GET: /Warranty/
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;

        string emailFrom = "onlineshoppingboutique463@gmail.com";
        string password = WebConfigurationManager.AppSettings["pass"];
        string emailToAdmin = "annalise.mamo@mcast.edu.mt";
        string subject = "Electros Ticket Report";

        public static int randumNum = 0;

        public ActionResult Index()
        {

            List<ProductOrder> productOrders = new List<ProductOrder>();

            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            List<Order> ordersList = new ProductOrderServ.ProductOrderClient().getPurchasesUnderWarranty(accountID).ToList();
            foreach (Order i in ordersList)
            {
                List<ProductOrder> po = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(i.ID).ToList();

                foreach (ProductOrder p in po)
                {
                    productOrders.Add(p);
                }
            }
            return View("Index",productOrders);
        }
       
        public ActionResult GenerateBarcode()
        {

            BarCodeServ.BarCodeSoapClient bc = new BarCodeServ.BarCodeSoapClient();

            BarCodeData barCodeData = new BarCodeData();
            barCodeData.Height = 125;
            barCodeData.Width = 225;
            barCodeData.Angle = 0;
            barCodeData.Ratio = 5;
            barCodeData.Module = 0;
            barCodeData.Left = 25;
            barCodeData.Top = 0;
            barCodeData.CheckSum = false;
            barCodeData.FontName = "Arial";
            barCodeData.BarColor = "Black";
            barCodeData.BGColor = "White";
            barCodeData.FontSize = 10.0f;
            barCodeData.barcodeOption = BarcodeOption.Both;
            barCodeData.barcodeType = BarcodeType.Code_2_5_interleaved;
            barCodeData.checkSumMethod = CheckSumMethod.None;
            barCodeData.showTextPosition = ShowTextPosition.BottomCenter;
            barCodeData.BarCodeImageFormat = ImageFormats.PNG;


            Random r = new Random();
            randumNum = r.Next(1000);


            Byte[] imgBarcode = bc.GenerateBarCode(barCodeData, randumNum.ToString());

            MemoryStream memStream = new MemoryStream(imgBarcode);
            Bitmap bm = new Bitmap(memStream);
            bm.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);

            System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBarcode));

           

            return new FileStreamResult(memStream, "image/png");



        }

        public ActionResult GenerateTicket(int pid)
        {
            FaultModel fm = new FaultModel();
            return View(fm);
        }
        
        [HttpPost]
        public ActionResult GenerateTicket(FaultModel fm, int pid)
        {
            
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            int ticketNum = new FaultsServ.FaultReportLogServiceClient().GenerateTicketNum();
            FaultReport checkTicketnum = new FaultsServ.FaultReportLogServiceClient().getTicketNum(ticketNum);
            if (checkTicketnum == null)
            {
                //FaultReport
                FaultReport fr = new FaultReport();
                //fr.ID = new int();
                fr.TicketNum = ticketNum;
                //add barcode
                BarCodeServ.BarCodeSoapClient bc = new BarCodeServ.BarCodeSoapClient();

                BarCodeData barCodeData = new BarCodeData();
                barCodeData.Height = 125;
                barCodeData.Width = 225;
                barCodeData.Angle = 0;
                barCodeData.Ratio = 5;
                barCodeData.Module = 0;
                barCodeData.Left = 25;
                barCodeData.Top = 0;
                barCodeData.CheckSum = false;
                barCodeData.FontName = "Arial";
                barCodeData.BarColor = "Black";
                barCodeData.BGColor = "White";
                barCodeData.FontSize = 10.0f;
                barCodeData.barcodeOption = BarcodeOption.Both;
                barCodeData.barcodeType = BarcodeType.Code_2_5_interleaved;
                barCodeData.checkSumMethod = CheckSumMethod.None;
                barCodeData.showTextPosition = ShowTextPosition.BottomCenter;
                barCodeData.BarCodeImageFormat = ImageFormats.PNG;


                Byte[] imgBarcode = bc.GenerateBarCode(barCodeData, randumNum.ToString());
                MemoryStream memStream = new MemoryStream(imgBarcode);
                Bitmap bm = new Bitmap(memStream);
                bm.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);
                System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(imgBarcode));
                

                //end of barcode method
                fr.Barcode = imgBarcode;
                fr.ProductID = pid;
                fr.AccountID = accountID;
                new FaultsServ.FaultReportLogServiceClient().Create(fr);

                //FaultLog 
                FaultReport details = new FaultsServ.FaultReportLogServiceClient().getFaultReportIDByAccountIDTicket(accountID, ticketNum);
                
                FaultLog fl = new FaultLog();
                fl.Status = "Reported";
                fl.Description = fm.Description + "Item has been reported but not yet picked up for service" ;
                fl.DateReport = System.DateTime.Now;
                fl.FaultReportID = details.ID;

                new FaultsServ.FaultReportLogServiceClient().CreateLog(fl);
                SendEmailToClient(accountID, image,pid,memStream);
                //SendEmailToClient(accountID, memStream,pid);
                return RedirectToAction("Index","Warranty");
            }
            else
            {
                //show error
            }
            return RedirectToAction("Index", "Warranty");
        }

        public void SendEmailToClient(int accountID, Image img, int pid, MemoryStream stream)
        {
            Product p = new ProductServ.ProductServiceClient().GetProductByID(pid);

            string username = Session["username"].ToString();
            Common.User details = new UserServ.UserServiceClient().getUSerByAccountID(accountID);
            
            string body = "Dear " + "\n" + details.Name + " " + details.Surname + " you ticket of "+p.Name+" of your fault has been reported" +img  ;

            
           Bitmap bm = new Bitmap(stream);
            bm.Save(HttpContext.Response.OutputStream, ImageFormat.Jpeg);
            //Attachment attachment = new Attachment(stream, "BarcodeImage.jpg");
            //img.Save(stream, ImageFormat.Jpeg);
           stream.Position = 0;

            //mail.Attachments.Add(new Attachment(stream, "image/jpg"));
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
               // mail.Attachments.Add(attachment);
                mail.Attachments.Add(new Attachment(stream, "Barcodeimg.jpg", "image/jpg"));
                mail.To.Add(details.Email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

    }
}
