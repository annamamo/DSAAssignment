using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FaultReportLogService" in code, svc and config file together.
    public class FaultReportLogService : IFaultReportLogService
    {
        /// <summary>
        /// This method is used to create a new record of type FaultReport
        /// </summary>
        /// <param name="faultReport">This parameter is of type FaultReport, which holds all the details
        /// that need to be stored in database relating the Fault Report</param>
        public void Create(Common.FaultReport faultReport)
        {
            new DAFaultReport().Create(faultReport);   
        }

        /// <summary>
        /// This method is used to create a new record of type FaultLog
        /// </summary>
        /// <param name="faultLog">This paramete is of type FaultLog, which hols all the details that need
        /// to be stored in the database relting the Fault Log</param>
        public void CreateLog(Common.FaultLog faultLog)
        {
            new DAFaultLog().CreateLog(faultLog);
        }

        /// <summary>
        /// This method is used to generate a ticket number which is of type int
        /// </summary>
        /// <returns>This method return an integer value holding the ticket number</returns>
        public int GenerateTicketNum()
        {
            Random r = new Random();
            int num = r.Next(1000000);
            return num;
        }

        //check if ticket num is unique
        /// <summary>
        /// This method is used to check if the given ticketNum already exists in the database records
        /// </summary>
        /// <param name="ticketNum">This parameter is of type integer, which holds a the ticket number</param>
        /// <returns>This method returns a record of type FaultReport</returns>
        public Common.FaultReport getTicketNum(int ticketNum)
        {
            return new DAFaultReport().getTicketNum(ticketNum);
        }

        /// <summary>
        /// This method is used to get a Fault Report record with the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type integer and hold the accountID of the user</param>
        /// <param name="ticketNum">This parameter is of tyoe integer and hols the ticket number of the user</param>
        /// <returns>This method return a record of type Fault Report</returns>
        public Common.FaultReport getFaultReportIDByAccountIDTicket(int accountID, int ticketNum)
        {
            return new DAFaultReport().getFaultReportIDByAccountIDTicket(accountID, ticketNum);
        }

        /// <summary>
        /// This method is used to get a list of Fault Logs by the given parameter which is the foreign key FaultReportID
        /// </summary>
        /// <param name="frID">This parameter is of type integer and hold the FaultReportID</param>
        /// <returns>This method return a list of records of type FaultLog</returns>
        public IEnumerable<Common.FaultLog> getFaultLogByReportID(int frID)
        {
            return new DAFaultLog().getFaultLogByReportID(frID);
        }

        /// <summary>
        /// This method is used to get a list of all the entries in the FaultLog table stored in the database
        /// </summary>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        public IEnumerable<Common.FaultLog> getFaultLogs()
        {
            return new DAFaultLog().getFaultLogs();
        }

        /// <summary>
        /// This method is used to get a list of Fault Reports by the user's accountID
        /// </summary>
        /// <param name="accountID">This parameter is of type integer and holds the user's accountID</param>
        /// <returns>This method return a list of recors of type FaultReport</returns>
        public IEnumerable<Common.FaultReport> getFaultReportIDByAccountID(int accountID)
        {
            return new DAFaultReport().getFaultReportIDByAccountID(accountID);
        }

        /// <summary>
        /// This method is used to get a Fault by the ID
        /// </summary>
        /// <param name="id">This parameter is of type integer and holds the fault ID</param>
        /// <returns>This method returns a record of tyoe FaultReport</returns>
        public Common.FaultReport getFaultByID(int id)
        {
            return new DAFaultReport().getFaultByID(id);
        }

        /// <summary>
        /// This method is used to get a list of records of Fault Logs depending on the given parameters
        /// </summary>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to Date</param>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        public IEnumerable<Common.FaultLog> searchLogByDates(DateTime dateFrom, DateTime dateTo)
        {
            return new DAFaultLog().searchLogByDates(dateFrom, dateTo);
        }

        //search all combinations
        /// <summary>
        /// This method is used to get a list of records of Fault Logs depending on the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <param name="reportID">This parameter is of type int and holds the fault report ID</param>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to date</param>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        public List<Common.FaultLog> search(int accountID, int reportID, DateTime dateFrom, DateTime dateTo)
        {
            return new DAFaultLog().search(accountID, reportID, dateFrom, dateTo).ToList();
        }



        /// <summary>
        /// This method is used to get a list of records of Fault Logs which are sorted by date
        /// </summary>
        /// <returns>This method returns a list of records of type FaultLog</returns>
        public IEnumerable<Common.FaultLog> sortByDate()
        {
            return new DAFaultLog().sortByDate();
            
        }

        /// <summary>
        /// This method is used to get a list of records of Fault Reports by the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's accountID</param>
        /// <param name="productID">This parameter is of type int and holds the product ID</param>
        /// <returns>This method returns a list of records of type FaultReport</returns>
        public IEnumerable<Common.FaultReport> getFaultByAccountIDPRoductID(int accountID, int productID)
        {
            return new DAFaultReport().getFaultByAccountIDPRoductID(accountID, productID);
        }
    }
}
