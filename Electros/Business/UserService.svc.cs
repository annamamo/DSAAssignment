using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using Data;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    public class UserService : IUserService
    {
        //public enum RegistrationResult { Successful, usernameExists, EmailExists }

        ElectrosDBEntities entities = new ElectrosDBEntities();
        public void Create(Common.User user, List<int> roles, Common.Account a)
        {
            //RegistrationResult result = RegistrationResult.Successful;
            //Account checkAccount = this.getAccountByUsername(a.Username);
            //User checkEmail = this.getUserByEmail(user.Email);

            //if (checkAccount == null && checkEmail == null)
            //{
                foreach (int roleID in roles)
                {
                    Role r = new DARole(entities).GetRoleByID(roleID);
                    a.Role.Add(r);
                }

                //Account ac = this.getAccountByUsername(a.Username);
                //user.AccountID = ac.ID;
                new DAUser(this.entities).Create(user);
            //    result = RegistrationResult.Successful;
            //}
            //else 
            //{
            //    if (checkAccount != null)
            //    {
            //        result = RegistrationResult.usernameExists;
            //    }
            //    else
            //    {
            //        result = RegistrationResult.EmailExists;
            //    }
            //}
            //return result;
        }


        public Account getAccountByUsername(string username)
        {
            return new DAAccount().getAccountByUsername(username);
        }


        public User getUserByEmail(string email)
        {
            return new DAUser().getUserByEmail(email);
        }




        public User getUSerByAccountID(int accountID)
        {
            return new DAUser().getUSerByAccountID(accountID);
        }
    }
}
