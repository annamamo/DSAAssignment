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
            
            //continuation of code

            int roleID = 0;
            if (rm.Password.Length < 6)
            {
                TempData["Message"] = "Password needs to be longer";
                //ViewBag.Msg = "Password needs to be longer";
                //return Content("PAssword longer");
                return RedirectToAction("RegisterUser");
            }
            else
            {
                Account checkAccount = new AccountServ.AccountServiceClient().getAccountByUsername(rm.Username);
                User checkEmail = new UserServ.UserServiceClient().getUserByEmail(rm.Email);
                int pin = Convert.ToInt32(rm.PIN);
                Account checkPin = new AccountServ.AccountServiceClient().getAccountByPin(pin);

                if (checkAccount == null && checkEmail == null && checkPin == null)
                {

                    
                        
                        Account a = new AccountServ.AccountServiceClient().getAccountByUsername(rm.Username);

                        string passpin = rm.Password + rm.PIN;
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
                    //rm.myUser.Email = rm.myUser
                        //USer
                        rm.myUser.Name = rm.Name;
                        rm.myUser.Surname = rm.Surname;
                        rm.myUser.Email = rm.Email;
                        rm.myUser.ResidanceName = rm.ResidanceName;
                        rm.myUser.StreetName = rm.StreetName;
                        rm.myUser.Mobile = rm.Mobile;
                        //Account
                        //rm.myAccount.Username = rm.Username;
                        //rm.myAccount.Password = rm.Password;
                        //// rm.myAccount.PIN = Convert.ToInt32(rm.PIN);
                        //rm.myAccount.PIN = Convert.ToInt32(rm.PIN);
                        Account acc = new Account();
                        acc.Username = rm.Username;
                        acc.Password = rm.Password;
                        acc.PIN = rm.PIN;
                        //new UserServ.UserServiceClient().Create(rm.myUser, arraylist, rm.myAccount);
                        new UserServ.UserServiceClient().Create(rm.myUser, arraylist, acc);
                    
                    
                }
                else
                {
                    if (checkAccount != null)
                    {
                        TempData["Message"] = "Username already exists";
                    }
                    else if(checkEmail != null)
                    {
                        TempData["Email"] = "Email already exists";
                    }
                    else if(checkPin != null)
                    {
                        TempData["PIN"] = "PIN already exists";
                    }
                    
                }
            }

            //return View("RegisterUser");
            return RedirectToAction("RegisterUser");
                
        }
    }
}
