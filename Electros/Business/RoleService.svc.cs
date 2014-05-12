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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoleService" in code, svc and config file together.
    public class RoleService : IRoleService
    {
        /// <summary>
        /// This method is used to get all the Roles stored in the database
        /// </summary>
        /// <returns>This method returns a list of type Role</returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return new DARole().GetAllRoles();
        }

        /// <summary>
        /// This method is used to get a Role by the given ID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the ID</param>
        /// <returns>This method returns a record of type Role</returns>
        public Role GetRoleByID(int id)
        {
            return new DARole().GetRoleByID(id);
        }

        /// <summary>
        /// This method is used to get a list of Roles depending on the username given
        /// </summary>
        /// <param name="username">This parameter is of type string and holds the user's username</param>
        /// <returns>This method returns a list of type Role</returns>
        public IEnumerable<Role> GetUserRoles(string username)
        {
            return new DAAccount().getAccountByUsername(username).Role.AsQueryable();
        }
    }
}
