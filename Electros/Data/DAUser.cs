using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAUser : ConnectionClass
    {
        public DAUser() : base() { }
        public DAUser(ElectrosDBEntities entities) : base(entities) { }

        public void Create(User user)
        {
           // entities.AddToUser(user);
            entities.User.AddObject(user);
            entities.SaveChanges();
        }

        //get email

        public User getUserByEmail(string email)
        {
            return entities.User.SingleOrDefault(e => e.Email == email);
        }

        public User getUSerByAccountID(int accountID)
        {
            return entities.User.SingleOrDefault(a => a.AccountID == accountID);
        }

    }
}
