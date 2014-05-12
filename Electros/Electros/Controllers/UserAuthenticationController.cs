using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electros.Models;
using Electros.AccountServ;
using System.Web.Security;
using Common;

namespace Electros.Controllers
{
    public class UserAuthenticationController : Controller
    {
        //
        // GET: /UserAuthentication/

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel data)
        {
            //try
            //{
                if (new AccountServiceClient().isAuthenticatedValid(data.username, data.pin))
                {
                    Account checktoken = new AccountServiceClient().getAccountByUsername(data.username);

                    string passpin = checktoken.Password + checktoken.PIN.ToString();
                    string token = new AccountServiceClient().Encrypt(passpin);
                    string decryptedToken = new AccountServiceClient().Decrypty(data.token);
                    //string checkValue = data
                    // if (token.Equals(data.token))
                    if (decryptedToken.Equals(passpin))
                    {
                        //check with if statement if token is the same with encryption
                        FormsAuthentication.RedirectFromLoginPage(data.username, true);
                        Session["username"] = data.username;
                        Session["accountid"] = checktoken.ID;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Error = "Invalid Login credentials";
                        return View();
                    }

                }
                else
                {
                    ViewBag.Error = "Invalid Login credentials";
                    return View();
                }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = "Invalid Login credentials";
            //}
            return View();
        }
        //for user to logoff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }

    }
}
