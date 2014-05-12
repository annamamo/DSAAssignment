using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;
using System.Web.Configuration;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;

namespace Electros.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;

        string emailFrom = "onlineshoppingboutique463@gmail.com";
        string password = WebConfigurationManager.AppSettings["pass"];
        string emailToAdmin = "annalise.mamo@mcast.edu.mt";
        string subject = "Electros Fault Report Notification";

        List<FaultLog> fl = new FaultsServ.FaultReportLogServiceClient().getFaultLogs().ToList();

        List<FaultLog> faultLog = new List<FaultLog>();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            //List<FaultLog> fl = new FaultsServ.FaultReportLogServiceClient().getFaultLogs().ToList();

            return View("Index",fl);
        }

        public ActionResult Search(string accountID, string faultID, string dateFrom, string dateTo)
        {
            
            //if(accountID != null && faultID == null && dateFrom == null && dateTo == null)
            if((accountID != null || accountID != "") && (faultID == null || faultID == "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
            {
                try
                {
                    int aID = Convert.ToInt32(accountID);
                    List<FaultReport> fr = new FaultsServ.FaultReportLogServiceClient().getFaultReportIDByAccountID(aID).ToList();
                    foreach (FaultReport f in fr)
                    {
                        List<FaultLog> flTemp = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID(f.ID).ToList();

                        foreach (FaultLog fl in flTemp)
                        {
                            faultLog.Add(fl);
                        }
                    }
                }
                catch(Exception ex)
                {
                    TempData["TypeError"] = "The ID is incorrect format or null (11)";
                    return View("Index", fl);
                }
            }
            else if ((accountID == null || accountID == "") && (faultID != null || faultID != "") && (dateFrom == null || dateFrom == "") && (dateTo == null || dateTo == ""))
            {
                try
                {
                    int fID = Convert.ToInt32(faultID);
                    List<FaultLog> flTemp = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID(fID).ToList();

                    foreach (FaultLog fl in flTemp)
                    {
                        faultLog.Add(fl);
                    }
                }
                catch (Exception ex)
                {
                    TempData["TypeError"] = "The ID is incorrect format or null (11)";
                    return View("Index", fl);
                }
            }
            else if((accountID == null || accountID == "") && (faultID == null || faultID == "") && (dateFrom != null || dateFrom != "") && (dateTo != null || dateTo != ""))
            {
                try
                {
                    DateTime from = Convert.ToDateTime(dateFrom);
                    DateTime to = Convert.ToDateTime(dateTo);
                    List<FaultLog> flTemp = new FaultsServ.FaultReportLogServiceClient().searchLogByDates(from, to).ToList();

                    foreach (FaultLog fl in flTemp)
                    {
                        faultLog.Add(fl);
                    }
                }
                catch (Exception ex)
                { 
                    TempData["DatesError"] = "The Dates are incorrect format or null (2014/12/12)";
                    return View("Index", fl);
                }
                
            }
             else if((accountID != null || !accountID.Equals("")) && (faultID != null || !faultID.Equals("")) && (dateFrom != null || !dateFrom.Equals("")) && (dateTo != null || !dateTo.Equals("")))
             {
                 try
                 {
                     DateTime from = Convert.ToDateTime(dateFrom);
                     DateTime to = Convert.ToDateTime(dateTo);
                     int aID = Convert.ToInt32(accountID);
                     int fID = Convert.ToInt32(faultID);

                     faultLog = new FaultsServ.FaultReportLogServiceClient().search(aID, fID, from, to).ToList();
                 }
                 catch (Exception ex)
                 {
                     TempData["TypeError"] = "The Dates and ID's are incorrect format or null (2014/12/12)";
                     return View("Index", fl);
                 }
             }
           // List<FaultLog> fl = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID
            return View("Index",faultLog);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Update(int reportID)
        {
            FaultModel fm = new FaultModel();
            return View(fm);
        }

        public void sendSMS(string fault)
        {
            WebClient clientSMS = new WebClient();
            // Add a user agent header in case the requested URI contains a query.
            clientSMS.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            clientSMS.QueryString.Add("user", "annamamo");
            clientSMS.QueryString.Add("password", "IKUTOKDVMOIbVC");
            clientSMS.QueryString.Add("api_id", "3477980");
            clientSMS.QueryString.Add("to", "35679231509");
            
            clientSMS.QueryString.Add("text", "Fault updated, Current Status is: " + fault + "");
            string baseurl = "http://api.clickatell.com/http/sendmsg";
            Stream data = clientSMS.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string sms = reader.ReadToEnd();
            data.Close();
            reader.Close();
            //Response.Redirect(sms);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(FaultModel fm, int reportID)
        {
            try
            {
                FaultLog fll = new FaultLog();
               // fll.Status = fm.Status;
                fll.Description = fm.Description;
                fll.DateReport = System.DateTime.Now.Date;
                fll.FaultReportID = reportID;
                //fll.Status = fm.stat;
                int idstat = Convert.ToInt32(fm.stat);
                if (idstat == 1)
                {
                    fll.Status = "Reported";
                    sendSMS("Reported");
                }
                else if (idstat == 2)
                {
                    fll.Status = "Picked up - Transit to main office";
                    sendSMS("Picked up - Transit to main office");
                }
                else if (idstat == 3)
                {
                    fll.Status = "Service in progress";
                    sendSMS("Service in progress");
                }
                else if (idstat == 4)
                {
                    fll.Status = "Service completed - Ready for Delivery";
                    sendSMS("Service completed - Ready for Delivery");
                }
                else if (idstat == 5)
                {
                    fll.Status = "Picked up - Transit to customer";
                    sendSMS("Picked up - Transit to customer");
                }
                else if (idstat == 6)
                {
                    fll.Status = "Fault Completed";
                    sendSMS("Fault Completed");
                }
                new FaultsServ.FaultReportLogServiceClient().CreateLog(fll);
                fl.Add(fll);

                SendEmailtoClient(reportID);
                return RedirectToAction("Index", fl);
            }
            catch (Exception ex)
            {
                TempData["CatchError"] = "An error was encountered. Please try again later";
                return RedirectToAction("Index", fl);
            }
        }

        public ActionResult Sort()
        {

            faultLog= new FaultsServ.FaultReportLogServiceClient().sortByDate().ToList();
            return RedirectToAction("Index", faultLog);
        }

        public void SendEmailtoClient(int reportID)
        {
            
            FaultReport fr = new FaultsServ.FaultReportLogServiceClient().getFaultByID(reportID);
            int accountID = (int)fr.AccountID;
            Common.User details = new UserServ.UserServiceClient().getUSerByAccountID(accountID);

            string body = "Dear " + "\n" + details.Name + " " + details.Surname;
            body += "<br />";
            body +=   " your ticket : " + fr.TicketNum + " regarding the fault has been updated";


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(details.Email);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body;
                

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
