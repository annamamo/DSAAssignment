using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DACountry : ConnectionClass
    {
        public DACountry() : base() { }

        public IEnumerable<Country> GetAllCountries()
        {
            return entities.Country.AsEnumerable();
        }
        public Country GetCountryByID(int id)
        {
            return entities.Country.SingleOrDefault(c => c.ID == id);
        }
    }
}
