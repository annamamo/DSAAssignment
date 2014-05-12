using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAFaultLog : ConnectionClass
    {
        public DAFaultLog() : base() { }

        public void CreateLog(FaultLog faultLog)
        {
            entities.AddToFaultLog(faultLog);
            entities.SaveChanges();
        }

        

        public IEnumerable<FaultLog> getFaultLogByReportID(int frID)
        {
            return entities.FaultLog.Where(fl => fl.FaultReportID == frID);
        }

        public IEnumerable<FaultLog> getFaultLogs()
        {
            return entities.FaultLog.AsEnumerable();
        }

        public IEnumerable<FaultLog> searchLogByDates(DateTime dateFrom, DateTime dateTo)
        {
            return entities.FaultLog.Where(fl => fl.DateReport >= dateFrom && fl.DateReport <= dateTo);
        }
        //search all combinations
        public IEnumerable<FaultLog> search(int accountID, int reportID, DateTime dateFrom, DateTime dateTo)
        {
            FaultReport f = new DAFaultReport().getFaultByID(reportID);
            return entities.FaultLog.Where(fl => fl.FaultReportID == reportID && f.AccountID == accountID && fl.DateReport >= dateFrom && fl.DateReport <= dateTo).ToList();
        }

        public IEnumerable<FaultLog> sortByDate()
        {
           // return test.OrderBy(t => t.DateReport);
            return entities.FaultLog.OrderBy(fl => fl.DateReport);
        }
        
    }
}
