using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFaultReportLogService" in both code and config file together.
    [ServiceContract]
    public interface IFaultReportLogService
    {
        /// <summary>
        /// This method is used to create a new record of type FaultReport
        /// </summary>
        /// <param name="faultReport">This parameter is of type FaultReport, which holds all the details
        /// that need to be stored in database relating the Fault Report</param>
        [OperationContract]
        void Create(Common.FaultReport faultReport);

        /// <summary>
        /// This method is used to create a new record of type FaultLog
        /// </summary>
        /// <param name="faultLog">This paramete is of type FaultLog, which hols all the details that need
        /// to be stored in the database relting the Fault Log</param>
        [OperationContract]
        void CreateLog(Common.FaultLog faultLog);

        /// <summary>
        /// This method is used to generate a ticket number which is of type int
        /// </summary>
        /// <returns>This method return an integer value holding the ticket number</returns>
        [OperationContract]
        int GenerateTicketNum();

        //to check if unique
        /// <summary>
        /// This method is used to check if the given ticketNum already exists in the database records
        /// </summary>
        /// <param name="ticketNum">This parameter is of type integer, which holds a the ticket number</param>
        /// <returns>This method returns a record of type FaultReport</returns>
        [OperationContract]
        Common.FaultReport getTicketNum(int ticketNum);

        //to get faultReport ID
        /// <summary>
        /// This method is used to get a Fault Report record with the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type integer and hold the accountID of the user</param>
        /// <param name="ticketNum">This parameter is of tyoe integer and hols the ticket number of the user</param>
        /// <returns>This method return a record of type Fault Report</returns>
        [OperationContract]
        Common.FaultReport getFaultReportIDByAccountIDTicket(int accountID, int ticketNum);

        
        /// <summary>
        /// This method is used to get a list of Fault Logs by the given parameter which is the foreign key FaultReportID
        /// </summary>
        /// <param name="frID">This parameter is of type integer and hold the FaultReportID</param>
        /// <returns>This method return a list of records of type FaultLog</returns>
        [OperationContract]
        IEnumerable<Common.FaultLog> getFaultLogByReportID(int frID);

        
        /// <summary>
        /// This method is used to get a list of all the entries in the FaultLog table stored in the database
        /// </summary>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        [OperationContract]
        IEnumerable<Common.FaultLog> getFaultLogs();

        
        /// <summary>
        /// This method is used to get a list of Fault Reports by the user's accountID
        /// </summary>
        /// <param name="accountID">This parameter is of type integer and holds the user's accountID</param>
        /// <returns>This method return a list of recors of type FaultReport</returns>
        [OperationContract]
        IEnumerable<Common.FaultReport> getFaultReportIDByAccountID(int accountID);
        

        
        /// <summary>
        /// This method is used to get a Fault by the ID
        /// </summary>
        /// <param name="id">This parameter is of type integer and holds the fault ID</param>
        /// <returns>This method returns a record of tyoe FaultReport</returns>
        [OperationContract]
        Common.FaultReport getFaultByID(int id);

        
        /// <summary>
        /// This method is used to get a list of records of Fault Logs depending on the given parameters
        /// </summary>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to Date</param>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        [OperationContract]
        IEnumerable<Common.FaultLog> searchLogByDates(DateTime dateFrom, DateTime dateTo);
        
        //search all combinations
        /// <summary>
        /// This method is used to get a list of records of Fault Logs depending on the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <param name="reportID">This parameter is of type int and holds the fault report ID</param>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to date</param>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        [OperationContract]
        List<Common.FaultLog> search(int accountID, int reportID, DateTime dateFrom, DateTime dateTo);

        //[OperationContract]
        //IEnumerable<Common.FaultReport> getFaultListByID(int id);

        /// <summary>
        /// This method is used to get a list of records of Fault Logs which are sorted by date
        /// </summary>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        [OperationContract]
        IEnumerable<Common.FaultLog> sortByDate();

        /// <summary>
        /// This method is used to get a list of records of Fault Reports by the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's accountID</param>
        /// <param name="productID">This parameter is of type int and holds the product ID</param>
        /// <returns>This method returns a list of records of type FaultReport</returns>
        [OperationContract]
        IEnumerable<Common.FaultReport> getFaultByAccountIDPRoductID(int accountID, int productID);
        
    }
}
