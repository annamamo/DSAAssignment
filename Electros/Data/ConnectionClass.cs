using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class ConnectionClass
    {
        public ElectrosDBEntities entities;

        public ConnectionClass()
        {
            entities = new ElectrosDBEntities();
        }
        public ConnectionClass(ElectrosDBEntities entities)
        {
            this.entities = entities;
        }
    }
}
