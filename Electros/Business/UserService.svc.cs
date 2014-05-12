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

        /// <summary>
        /// This method is used to create a User, an account and the user's selected roles
        /// </summary>
        /// <param name="user">This parameter is of type User and holds all the details that need to be
        /// stored in the database</param>
        /// <param name="roles">This parameter consists of a List of type int and holds all the details that need to be
        /// stored in the database</param>
        /// <param name="a">This parameter is of type Account and holds all the details that need to be
        /// stored in the database</param>
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

        /// <summary>
        /// This method is used to get an Account by the given username
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the username</param>
        /// <returns>This method returns a record of type Account</returns>
        public Account getAccountByUsername(string username)
        {
            return new DAAccount().getAccountByUsername(username);
        }

        /// <summary>
        /// This method is used to get an Account by the given email
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the email of a user</param>
        /// <returns>This method returns a record of type User</returns>
        public User getUserByEmail(string email)
        {
            return new DAUser().getUserByEmail(email);
        }



        /// <summary>
        /// This method is used to get an Account by the given accountID
        /// </summary>
        /// <param name="username">This parameter is of type int and holds the accountID of a user</param>
        /// <returns>This method returns a record of type User</returns>
        public User getUSerByAccountID(int accountID)
        {
            return new DAUser().getUSerByAccountID(accountID);
        }
    }
}
