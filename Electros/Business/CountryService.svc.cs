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
        /// <summary>
        /// This method is used to get a list of all the countries stored in the database
        /// </summary>
        /// <returns>The method returns a list of type Country</returns>
        public IEnumerable<Country> GetAllCountries()
        {
            return new DACountry().GetAllCountries();
        }

        /// <summary>
        /// This method is used to get a record of type Country by a given countryID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the country ID</param>
        /// <returns>The method returns a record of the type Country</returns>
        public Country GetCountryByID(int id)
        {
            return new DACountry().GetCountryByID(id);
        }
    }
}
