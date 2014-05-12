using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using EncryptDecrypt;

namespace Data
{
    public class DAAccount : ConnectionClass
    {
        public DAAccount() : base() { }

        public void Create(Account account)
        {
            //entities.AddToAccount(account);
            entities.Account.AddObject(account);
            entities.SaveChanges();
        }

        public Account getAccountByUsername(string username)
        {
            return entities.Account.SingleOrDefault(u => u.Username == username);
        }
        //method for login to check if user exists
        public bool isAuthenticatedValid(string username, int pin)
        {
            if(entities.Account.SingleOrDefault(u => u.Username == username && u.PIN == pin) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Account getAccountByPin(int pin)
        {
            return entities.Account.SingleOrDefault(a => a.PIN == pin);
        }
        
    }
}
