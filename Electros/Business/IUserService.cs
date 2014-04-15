using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        
        
        [OperationContract]
        void Create(Common.User user, List<int> roles, Common.Account a);

        [OperationContract]
        Account getAccountByUsername(string username);

        [OperationContract]
        User getUserByEmail(string email);

        [OperationContract]
        Common.User getUSerByAccountID(int accountID);
        
    }
}
