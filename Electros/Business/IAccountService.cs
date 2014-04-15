using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;
using EncryptDecrypt;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        //[OperationContract]
        //void Create(Account account);

        [OperationContract]
        Account getAccountByUsername(string username);

        [OperationContract]
        String Encrypt(string passpin);

        //[OperationContract]
        //void AddUser(Account a, List<Role> listofRoles);

        [OperationContract]
        bool isAuthenticatedValid(string username, int pin);
        

    }
}
