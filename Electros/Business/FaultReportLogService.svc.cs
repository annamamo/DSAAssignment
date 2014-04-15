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

        public void Create(Common.FaultReport faultReport)
        {
            new DAFaultReport().Create(faultReport);   
        }


        public void CreateLog(Common.FaultLog faultLog)
        {
            new DAFaultLog().CreateLog(faultLog);
        }


        public int GenerateTicketNum()
        {
            Random r = new Random();
            int num = r.Next(10000000);
            return num;
        }

        //check if ticket num is unique
        public Common.FaultReport getTicketNum(int ticketNum)
        {
            return new DAFaultReport().getTicketNum(ticketNum);
        }
        //get faultReportId
        public Common.FaultReport getFaultReportIDByAccountIDTicket(int accountID, int ticketNum)
        {
            return new DAFaultReport().getFaultReportIDByAccountIDTicket(accountID, ticketNum);
        }


        public IEnumerable<Common.FaultLog> getFaultLogByReportID(int frID)
        {
            return new DAFaultLog().getFaultLogByReportID(frID);
        }


        public IEnumerable<Common.FaultLog> getFaultLogs()
        {
            return new DAFaultLog().getFaultLogs();
        }


        public IEnumerable<Common.FaultReport> getFaultReportIDByAccountID(int accountID)
        {
            return new DAFaultReport().getFaultReportIDByAccountID(accountID);
        }


        public Common.FaultReport getFaultByID(int id)
        {
            return new DAFaultReport().getFaultByID(id);
        }
    }
}
