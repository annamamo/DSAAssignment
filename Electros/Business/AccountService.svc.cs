using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using Data;
using EncryptDecrypt;


namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountService" in code, svc and config file together.
    public class AccountService : IAccountService
    {

        //public void Create(Account account)
        //{
        //    new DAAccount().Create(account);
        //}


        public Account getAccountByUsername(string username)
        {
            return new DAAccount().getAccountByUsername(username);
        }


        public string Encrypt(string passpin)
        {
            return new EncryptDecrypt.Encryption().Encrypt(passpin);
        }

        //check for login
        public bool isAuthenticatedValid(string username, int pin)
        {
            return new DAAccount().isAuthenticatedValid(username, pin);
        }
    }
}
