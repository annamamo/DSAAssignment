using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITownService" in both code and config file together.
    [ServiceContract]
    public interface ITownService
    {
        /// <summary>
        /// This method is used to get a list of all the Towns stored in the database
        /// </summary>
        /// <returns>This method returns a list of type Town</returns>
        [OperationContract]
        IEnumerable<Town> GetAllTowns();

        /// <summary>
        /// This method is used to get a record of type Town depending on the given ID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the ID</param>
        /// <returns>This method returns a record of type Town</returns>
        [OperationContract]
        Town GetTownByID(int id);
    }
}
