using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.UI.WebControls;


namespace Electros.Models
{
    public class FaultModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        //public Image image { get; set; }

        public virtual FaultReport myFaultReport { get; set; }
    }
}