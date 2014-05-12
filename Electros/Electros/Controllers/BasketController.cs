using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mime;

namespace Electros.Controllers
{
    public class BasketController : Controller
    {

        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;

        string emailFrom = "onlineshoppingboutique463@gmail.com";
        string password = WebConfigurationManager.AppSettings["pass"];
        string emailToAdmin = "annalise.mamo@mcast.edu.mt";
        string subject = "Electros Statement Report";
        //
        // GET: /Basket/

        public ActionResult Index()
        {
            
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            if (a != null)
            {
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            if (o != null)
            {
                int orderID = o.ID;

                List<ProductOrder> productOrders = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(orderID).ToList();

                //to show totalPrice
                decimal price;
                int qty;
                decimal totalPrice = 0;
                foreach (ProductOrder i in productOrders)
                {
                    Product product = new ProductServ.ProductServiceClient().GetProductByID(i.ProductID);

                    price = Convert.ToDecimal(i.Product.Price);
                    qty = Convert.ToInt32(i.Quantity);
                    totalPrice += price * qty;
                }
                ViewData["totalPrice"] = totalPrice;
                return View("Index", productOrders);
            }
            else {
                return View("Index",new List<ProductOrder>());
            }
            }
            else
            {
                return RedirectToAction("Login", "UserAuthentication");
            }
        }

       
        public ActionResult Delete(int productID)
        {
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            int orderID = o.ID;

            new ProductOrderServ.ProductOrderClient().DeleteProductOrderByIDs(productID, orderID);
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            int orderID = o.ID;

            Order order = new Order();
            order.ID = o.ID;
            order.DateOfPurchase = o.DateOfPurchase;
            order.WarrantyExpiryDate = o.WarrantyExpiryDate;
            order.Status = "Shipped";
            order.AccountID = o.AccountID;
            
            foreach (ProductOrder p in o.ProductOrder)
            {
                ProductServ.ProductServiceClient productClient = new ProductServ.ProductServiceClient();
                Product product = productClient.GetProductByID(p.ProductID);
                product.StockAmount = product.StockAmount - p.Quantity;
                productClient.UpdateProductStock(product.StockAmount.Value,product.ID);
            }
            //Product p = new ProductServ.ProductServiceClient().GetProductByID(o.ProductOrder.
            new ProductOrderServ.ProductOrderClient().UpdateOrder(order);
            return RedirectToAction("ProductList", "Product");
        }

        List<ProductOrder> productOrders = new List<ProductOrder>();

        [Authorize(Roles = "Admin, User")]
        public ActionResult UserHistory()
        {

            try
            {
                string username = Session["username"].ToString();
                Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
                int accountID = a.ID;

                List<Order> ordersList = new ProductOrderServ.ProductOrderClient().getShippedOrders(accountID).ToList();



                foreach (Order i in ordersList)
                {
                    List<ProductOrder> po = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(i.ID).ToList();

                    foreach (ProductOrder p in po)
                    {
                        productOrders.Add(p);
                    }
                }

                ProductModel pm = new ProductModel();
                pm.productOrderList = productOrders;
                return View("UserHistory", pm);
            }
            catch (Exception ex)
            {
                TempData["CatchError"] = "An error was encountered. Please try again later";
                return View("UserHistory", productOrders);
            }
        }


        DateTime from;
        DateTime to;
        public ActionResult Filter(string dateFrom, string dateTo)
        {
            DateTime parsed;
            try
            {
                if (dateFrom.Equals("") && dateTo.Equals(""))
                {
                    TempData["NullMsg"] = "Dates cannot be null";
                    return RedirectToAction("UserHistory");
                }
                //if (!Decimal.TryParse(lowPrice, out parsed) && !Decimal.TryParse(highPrice, out parsed)  )
                if (!DateTime.TryParse(dateFrom, out parsed) && !DateTime.TryParse(dateTo, out parsed))
                {
                    TempData["DatesError"] = "The Dates are incorrect format or null (2014/12/12)";
                    return RedirectToAction("UserHistory");
                }
                else
                {
                    from = Convert.ToDateTime(dateFrom);
                     to = Convert.ToDateTime(dateTo);
                    //try
                    //{
                    //    from = Convert.ToDateTime(dateFrom);
                    //    to = Convert.ToDateTime(dateTo);
                    //}
                    //catch (Exception e)
                    //{
                    //    string user = Session["username"].ToString();
                    //    Account aa = new AccountServ.AccountServiceClient().getAccountByUsername(user);
                    //    int accID = aa.ID;

                    //    List<Order> oList = new ProductOrderServ.ProductOrderClient().getShippedOrders(accID).ToList();
                    //    foreach (Order i in oList)
                    //    {
                    //        List<ProductOrder> po = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(i.ID).ToList();

                    //        foreach (ProductOrder p in po)
                    //        {
                    //            productOrders.Add(p);
                    //        }
                    //    }
                    //    //change
                    //    ProductModel pm1 = new ProductModel();
                    //    pm1.productOrderList = productOrders;
                    //    pm1.from = Convert.ToDateTime(dateFrom);
                    //    pm1.to = Convert.ToDateTime(dateTo);
                    //    TempData["DatesError"] = "The Dates are incorrect format or null (2014/12/12)";
                    //   // return View("UserHistory", productOrders);
                    //    return View("UserHistory",pm1);
                    //}
                    TempData["StoreDataFrom"] = from;
                    TempData["StoreDataTo"] = to;
                    string username = Session["username"].ToString();
                    Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
                    int accountID = a.ID;

                    List<Order> ordersList = new ProductServ.ProductServiceClient().getPurchasesByDates(accountID, from, to).ToList();
                    //new ProductOrderServ.ProductOrderClient().getShippedOrders(accountID).ToList();
                    // List<Order>


                    foreach (Order i in ordersList)
                    {
                        List<ProductOrder> po = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(i.ID).ToList();

                        foreach (ProductOrder p in po)
                        {
                            productOrders.Add(p);
                        }
                    }

                    ProductModel pm = new ProductModel();
                    pm.productOrderList = productOrders;
                    pm.from = Convert.ToDateTime(dateFrom);
                    pm.to = Convert.ToDateTime(dateTo);
                    //pm.myProduct

                    return View("UserHistory", pm);
                }
            }
            catch (Exception ex)
            {
                //ProductModel pm = new ProductModel();
                //pm.productOrderList = productOrders;
                //pm.from = Convert.ToDateTime(dateFrom);
                //pm.to = Convert.ToDateTime(dateTo);
                TempData["CatchError"] = "An error was encountered. Please try again later";
                return View("UserHistory", productOrders);
               // return View("UserHistory",pm);
            }
        }

        [Authorize(Roles = "Admin, User")]
        public ActionResult PostComment(int proID)
        {
            Product p = new ProductServ.ProductServiceClient().GetProductByID(proID);
            CommentModel model = new CommentModel();
            model.myProduct = p;
            return View(model);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult PostComment(CommentModel cm, int proID)
        {
            try
            {
                string username = Session["username"].ToString();
                Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
                int accountID = a.ID;

                Comment c = new Comment();
                c.Comment1 = cm.Comment;
                c.ProductID = proID;
                c.AccountID = accountID;

                Rating r = new Rating();
                r.Rating1 = cm.rating;
                r.AccountID = a.ID;
                r.ProductID = proID;

                new ProductServ.ProductServiceClient().CreateRating(r);

                new ProductServ.ProductServiceClient().Create(c);
                return RedirectToAction("UserHistory");
            }
            catch (Exception e)
            {
                TempData["CatchError"] = "An error was encountered. Please try again later";
                //return RedirectToAction("UserHistory");
                return View("PostComment", cm);
            }
        }

        public ActionResult Details(int pid, int oid)
        {
            
            ProductOrder po = new ProductOrderServ.ProductOrderClient().getProductOrderID(pid, oid);
            //Product p = new ProductServ.ProductServiceClient().GetProductByID(id);
            //to show fault
           
           
            return View("Details",po);
        }

        public ActionResult ShowReport(int productID, int orderID, string dateF, string dateT)
        {
            ReportModel model = new ReportModel();

            ViewBag.Title = "Electros";
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getOrderByIDs(accountID, orderID);

            Product p = new ProductServ.ProductServiceClient().GetProductByID(productID);
            List<FaultReport> fr = new FaultsServ.FaultReportLogServiceClient().getFaultByAccountIDPRoductID(accountID, productID).ToList();
            model.myFaultReport = fr;
            List<FaultLog> faultLogList = new List<FaultLog>();
            foreach (FaultReport f in fr)
            {
                List<FaultLog>  flTemp = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID(f.ID).ToList();
                foreach (FaultLog fl in flTemp)
                {
                    //faultLogList.Add(fl);
                    model.myFaultLog = flTemp;
                }
            }

            if (model.myFaultLog == null)
            { 
                TempData["NoFault"] = "The item selected has no faults";
                return RedirectToAction("UserHistory");
            }
            model.myProduct = p;
            //model.myFaultReport = fr;
            //model.myFaultLog = faultLogList;
            model.myOrder = o;
            //model.from = Convert.ToDateTime(TempData["StoreDataFrom"]) ;
            //model.to = Convert.ToDateTime(TempData["StoreDataTo"]);
            model.from = Convert.ToDateTime(dateF);
            model.to = Convert.ToDateTime(dateT);

            sendEmailToClient(accountID, model);

            return new RazorPDF.PdfResult(model,"ShowReport");
            //return View(model);
        }

        //[HttpPost]
        //public ActionResult PDFReport(ReportModel model)
        //{
        //    return new RazorPDF.PdfResult(model, "ShowReport");
        //    //return View("ShowReport");
        //}

        public string Render( Controller controller, string viewName, object model)
        {
            controller.ViewData.Model = model;

            using ( var sw = new StringWriter() )
            {
                var viewResult = ViewEngines.Engines.FindView(this.ControllerContext, viewName,null);
                var viewContext = new ViewContext(this.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(this.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public void sendEmailToClient(int accountID, ReportModel rm)
        { 
            
            BasketController bc = new BasketController();
            
            string data = Render(bc,"ShowReport",rm);

           
            //stream.Position = 0;
            string username = Session["username"].ToString();
            Common.User details = new UserServ.UserServiceClient().getUSerByAccountID(accountID);
            
            string body = "Dear " + "\n" + details.Name + " " + details.Surname + "" ;
            body += "<br />";
            body += "A PDF attachment has been sent regarding the "+ rm.myProduct.Name+" with the fault details";
           
           // MemoryStream stream = new MemoryStream(byteArray);
          //  Attachment attachment = AttachmentHelper.CreateAttachment(data, "Report.pdf", TransferEncoding.Base64);
           // byte[] stringBytes = System.Text.Encoding.ASCII.GetBytes(data);
           // MemoryStream stream = new System.IO.MemoryStream(stringBytes);
           // //stream.Write(stringBytes, 0, stringBytes.Length);
             
           //stream.Position = 0;

            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
           
            doc.Add(new Paragraph("ELECTROS"));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Date From : "+rm.from.ToShortDateString()+"  Date To : "+rm.to.ToShortDateString()));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Item"));
            doc.Add(new Paragraph("ProductID   "+" "+ "Name             "+" " +"Price             "+" "+" Date of Purchase        "+"    Warranty Expiry Date"));
            doc.Add(new Paragraph(rm.myProduct.ID +"              " + rm.myProduct.Name +"             " + rm.myProduct.Price +
                "             "+ Convert.ToDateTime(rm.myOrder.DateOfPurchase).ToShortDateString() + "                     "+Convert.ToDateTime(rm.myOrder.WarrantyExpiryDate).ToShortDateString()));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Fault"));
            foreach (FaultLog fl in rm.myFaultLog)
            {
                doc.Add(new Paragraph("FaultID     " + "       " + "Date             " + " " + "Status                   " + " " + "Fault Description        "));
                doc.Add(new Paragraph(fl.FaultReportID + "              " + Convert.ToDateTime(fl.DateReport).ToShortDateString() + "       " + fl.Status + "                   " + fl.Description + " " ));
                doc.Add(new Paragraph(""));
            }
            doc.Add(new Paragraph(""));
            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

           
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                //mail.Attachments.Add(attachment);
                mail.Attachments.Add(new Attachment(memoryStream, "Report.pdf"));
                mail.To.Add(details.Email);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;

                    //+" "+data;
                

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
