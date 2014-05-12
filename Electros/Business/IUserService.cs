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
        
        /// <summary>
        /// This method is used to create a User, an account and the user's selected roles
        /// </summary>
        /// <param name="user">This parameter is of type User and holds all the details that need to be
        /// stored in the database</param>
        /// <param name="roles">This parameter consists of a List of type int and holds all the details that need to be
        /// stored in the database</param>
        /// <param name="a">This parameter is of type Account and holds all the details that need to be
        /// stored in the database</param>
        [OperationContract]
        void Create(Common.User user, List<int> roles, Common.Account a);

        /// <summary>
        /// This method is used to get an Account by the given username
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the username</param>
        /// <returns>This method returns a record of type Account</returns>
        [OperationContract]
        Account getAccountByUsername(string username);

        /// <summary>
        /// This method is used to get an Account by the given email
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the email of a user</param>
        /// <returns>This method returns a record of type User</returns>
        [OperationContract]
        User getUserByEmail(string email);

        /// <summary>
        /// This method is used to get an Account by the given accountID
        /// </summary>
        /// <param name="username">This parameter is of type int and holds the accountID of a user</param>
        /// <returns>This method returns a record of type User</returns>
        [OperationContract]
        Common.User getUSerByAccountID(int accountID);
        
    }
}
