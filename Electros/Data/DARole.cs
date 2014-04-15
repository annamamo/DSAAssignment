using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DARole : ConnectionClass
    {
        public DARole() : base() { }
        public DARole(ElectrosDBEntities entities) : base(entities) { }
        
        public IEnumerable<Role> GetAllRoles()
        {
            return entities.Role.AsEnumerable();
        }

        public Role GetRoleByID(int id)
        {
            return entities.Role.SingleOrDefault(r => r.ID == id);
        }
    }
}
