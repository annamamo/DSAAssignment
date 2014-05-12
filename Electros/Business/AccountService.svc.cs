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

        /// <summary>
        /// This method will get an account with the given username.
        /// </summary>
        /// <param name="username">The username will be passed as a string type, to retrieve the account</param>
        /// <returns>he method will return an Account record.</returns>
        public Account getAccountByUsername(string username)
        {
            return new DAAccount().getAccountByUsername(username);
        }

        /// <summary>
        /// This method will encrypted the given parameter
        /// </summary>
        /// <param name="passpin">The passpin is a string which contains the password and pin of the user</param>
        /// <returns>The method will return an encrypted value </returns>
        public string Encrypt(string passpin)
        {
            return new EncryptDecrypt.Encryption().Encrypt(passpin);
        }

        //check for login
        /// <summary>
        /// This method is used to check if the user exists in the database or not.
        /// </summary>
        /// <param name="username">The username is of type string, which contains the username of the user</param>
        /// <param name="pin">The pin is of type int, which contains the pin of the user</param>
        /// <returns>The methods return a bool value</returns>
        public bool isAuthenticatedValid(string username, int pin)
        {
            return new DAAccount().isAuthenticatedValid(username, pin);
        }

        /// <summary>
        /// This method is used to get an Account of a user by the given pin
        /// </summary>
        /// <param name="pin">The pin is of type int, which belongs to the user</param>
        /// <returns>The method will return a record of type Account</returns>
        public Account getAccountByPin(int pin)
        {
            return new DAAccount().getAccountByPin(pin);
        }

        /// <summary>
        /// This method will decrypt the given parameter
        /// </summary>
        /// <param name="passpin">The passpin is a string which contain the password and pin of the user which
        /// are currently encrypted</param>
        /// <returns>The method will return a decrypted value of the passpin</returns>
        public string Decrypty(string passpin)
        {
            return new EncryptDecrypt.Encryption().Decrypt(passpin); 
        }
    }
}
