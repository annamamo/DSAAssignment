using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoleService" in both code and config file together.
    [ServiceContract]
    public interface IRoleService
    {
        /// <summary>
        /// This method is used to get all the Roles stored in the database
        /// </summary>
        /// <returns>This method returns a list of type Role</returns>
        [OperationContract]
        IEnumerable<Role> GetAllRoles();

        /// <summary>
        /// This method is used to get a Role by the given ID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the ID</param>
        /// <returns>This method returns a record of type Role</returns>
        [OperationContract]
        Role GetRoleByID(int id);

        /// <summary>
        /// This method is used to get a list of Roles depending on the username given
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the user's username</param>
        /// <returns>This method returns a list of type Role</returns>
        [OperationContract]
        IEnumerable<Common.Role> GetUserRoles(string username);
    }
}
