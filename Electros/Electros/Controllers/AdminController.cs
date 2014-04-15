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

        public ActionResult Index()
        {
            //List<FaultLog> fl = new FaultsServ.FaultReportLogServiceClient().getFaultLogs().ToList();

            return View("Index",fl);
        }

        public ActionResult Search(int accountID)
        {

            List<FaultReport> fr = new FaultsServ.FaultReportLogServiceClient().getFaultReportIDByAccountID(accountID).ToList();

            List<FaultLog> faultLog = new List<FaultLog>();

            foreach(FaultReport f in fr)
            {
                List<FaultLog> flTemp = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID(f.ID).ToList();
                
                foreach(FaultLog fl in flTemp)
                {
                    faultLog.Add(fl);
                }
            }

           // List<FaultLog> fl = new FaultsServ.FaultReportLogServiceClient().getFaultLogByReportID
            return View("Index",faultLog);
        }

        public ActionResult Update(int reportID)
        {
            FaultModel fm = new FaultModel();
            return View(fm);
        }

        [HttpPost]
        public ActionResult Update(FaultModel fm, int reportID)
        {

            FaultLog fll = new FaultLog();
            fll.Status = fm.Status;
            fll.Description = fm.Description;
            fll.DateReport = System.DateTime.Now.Date;
            fll.FaultReportID = reportID;

            new FaultsServ.FaultReportLogServiceClient().CreateLog(fll);
            fl.Add(fll);

            SendEmailtoClient(reportID);
            return RedirectToAction("Index",fl);
        }

        public void SendEmailtoClient(int reportID)
        {
            
            FaultReport fr = new FaultsServ.FaultReportLogServiceClient().getFaultByID(reportID);
            int accountID = (int)fr.AccountID;
            Common.User details = new UserServ.UserServiceClient().getUSerByAccountID(accountID);

            string body = "Dear " + "\n" + details.Name + " " + details.Surname + " your ticket : " + fr.TicketNum + " regarding the fault has been updated";


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
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
