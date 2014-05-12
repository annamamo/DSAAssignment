using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace Electros.Models
{
    public class ReportModel
    {
        public Product myProduct { get; set; }
        public List<FaultReport> myFaultReport { get; set; }
        public List<FaultLog> myFaultLog { get; set; }
        public Order myOrder { get; set; }

        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}