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
    }
}
