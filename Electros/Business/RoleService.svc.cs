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

        public IEnumerable<Role> GetAllRoles()
        {
            return new DARole().GetAllRoles();
        }

        public Role GetRoleByID(int id)
        {
            return new DARole().GetRoleByID(id);
        }
    }
}
