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
        [OperationContract]
        void Create(Common.FaultReport faultReport);

        [OperationContract]
        void CreateLog(Common.FaultLog faultLog);

        [OperationContract]
        int GenerateTicketNum();

        //to check if unique
        [OperationContract]
        Common.FaultReport getTicketNum(int ticketNum);

        //to get faultReport ID
        [OperationContract]
        Common.FaultReport getFaultReportIDByAccountIDTicket(int accountID, int ticketNum);

        //get list of fault logs by the foreign key faultreportID
        [OperationContract]
        IEnumerable<Common.FaultLog> getFaultLogByReportID(int frID);

        //get all entries in faultLog
        [OperationContract]
        IEnumerable<Common.FaultLog> getFaultLogs();

        //get report by accountID
        [OperationContract]
        IEnumerable<Common.FaultReport> getFaultReportIDByAccountID(int accountID);
        

        //get fault by id
        [OperationContract]
        Common.FaultReport getFaultByID(int id);
        

        
        
    }
}
