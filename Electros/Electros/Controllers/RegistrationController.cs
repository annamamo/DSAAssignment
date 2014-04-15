using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Electros.Models;
using Common;

namespace Electros.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/

        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "Admin, Auditor")]
        public ActionResult RegisterUser()
        {
            return View(new Models.RegistrationModel());
        }
        public enum RegistrationResult { Successful, usernameExists, EmailExists }

        [HttpPost]
        public ActionResult RegisterUser(RegistrationModel rm)
        {
            int roleID = 0;
            if (rm.myAccount.Password.Length < 6)
            {
                TempData["Message"] = "Password needs to be longer";
                //ViewBag.Msg = "Password needs to be longer";
                //return Content("PAssword longer");
                return RedirectToAction("RegisterUser");
            }
            else
            {
                Account checkAccount = new AccountServ.AccountServiceClient().getAccountByUsername(rm.myAccount.Username);
                User checkEmail = new UserServ.UserServiceClient().getUserByEmail(rm.myUser.Email);

                if (checkAccount == null && checkEmail == null )
                {

                    
                        
                        Account a = new AccountServ.AccountServiceClient().getAccountByUsername(rm.myAccount.Username);

                        string passpin = rm.myAccount.Password + rm.myAccount.PIN;
                        string token = new AccountServ.AccountServiceClient().Encrypt(passpin);
                        TempData["Token"] = token;

                        List<int> add = new List<int>();
                        for (int i = 0; i < rm.roles.Count; i++)
                        {
                            if (rm.roles[i].Checked)
                            {
                                roleID = rm.myRole[i].ID;
                                add.Add(roleID);
                            }
                        }
                        int[] arraylist = add.ToArray();
                        new UserServ.UserServiceClient().Create(rm.myUser, arraylist, rm.myAccount);
                    
                    
                    
                }
                else
                {
                    if (checkAccount != null)
                    {
                        TempData["Message"] = "Username already exists";
                    }
                    else if(checkEmail != null)
                    {
                        TempData["Message"] = "Email already exists";
                    }
                    
                }
            }

            //return View("RegisterUser");
            return RedirectToAction("RegisterUser");
                
        }
    }
}
