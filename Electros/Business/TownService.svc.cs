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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TownService" in code, svc and config file together.
    public class TownService : ITownService
    {

        public IEnumerable<Town> GetAllTowns()
        {
            return new DATown().GetAllTowns();
        }

        public Town GetTownByID(int id)
        {
            return new DATown().GetTownByID(id);
        }
    }
}
