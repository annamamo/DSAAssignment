using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICountryService" in both code and config file together.
    [ServiceContract]
    public interface ICountryService
    {
        /// <summary>
        /// This method is used to get a list of all the countries stored in the database
        /// </summary>
        /// <returns>The method returns a list of type Country</returns>
        [OperationContract]
        IEnumerable<Country> GetAllCountries();

        /// <summary>
        /// This method is used to get a record of type Country by a given countryID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the country ID</param>
        /// <returns>The method returns a record of the type Country</returns>
        [OperationContract]
        Country GetCountryByID(int id);
    }
}
