using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
    public class DAFaultReport : ConnectionClass
    {
        public DAFaultReport() : base() { }

        public void Create(FaultReport faultReport)
        {
            entities.AddToFaultReport(faultReport);
            entities.SaveChanges();
        }

        public FaultReport getFaultReportIDByAccountIDTicket(int accountID, int ticketNum)
        {
            return entities.FaultReport.SingleOrDefault(fr => fr.AccountID == accountID && fr.TicketNum == ticketNum); 
        }

        //to check if unqiue
        public FaultReport getTicketNum(int ticketNum)
        {
            return entities.FaultReport.SingleOrDefault(fr => fr.TicketNum == ticketNum);
        }

        public IEnumerable<FaultReport> getFaultReportIDByAccountID(int accountID)
        {
            return entities.FaultReport.Where(fr => fr.AccountID == accountID);
        }

        public FaultReport getFaultByID(int id)
        {
            return entities.FaultReport.SingleOrDefault(fr => fr.ID == id);
        }
    }
}
