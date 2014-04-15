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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CountryService" in code, svc and config file together.
    public class CountryService : ICountryService
    {

        public IEnumerable<Country> GetAllCountries()
        {
            return new DACountry().GetAllCountries();
        }

        public Country GetCountryByID(int id)
        {
            return new DACountry().GetCountryByID(id);
        }
    }
}
