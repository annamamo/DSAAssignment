using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Electros.Models
{
    public class FaultModel
    {
        public int ID { get; set; }

         [Required(ErrorMessage = "The Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        public string Description { get; set; }
        public DateTime DateReported { get; set; }
        //public Image image { get; set; }

        public virtual FaultReport myFaultReport { get; set; }

        public List<SelectList> StatusList { get; set; }

        //public FaultModel()
        //{
        //    //myRole = new List<Role>(new RoleServ.RoleServiceClient().GetAllRoles());
        //    StatusList = new List<SelectList>();
        //    StatusList.Add(new SelectList ("Reported"));
        //    StatusList.Add(new SelectList("Picked up - Transit to main office"));
        //    StatusList.Add(new SelectList("Service in progress"));
        //    StatusList.Add(new SelectList("Service completed - Ready for Delivery"));
        //    StatusList.Add(new SelectList("Picked up - Transit to customer"));
        //    StatusList.Add(new SelectList("Fault Completed"));
        //}

        public int IdStatus { get; set; }
        public string stat { get; set; }
        public IEnumerable<FaultModel> GetStatus()
        {
            return new List<FaultModel>
                            {
                                new FaultModel() {IdStatus = 1, stat = "Reported"},
                                new FaultModel() {IdStatus = 2, stat = "Picked up - Transit to main office"},
                                new FaultModel() {IdStatus = 3, stat = "Service in progress"},
                                new FaultModel() {IdStatus = 4, stat = "Service completed - Ready for Delivery"},
                                new FaultModel() {IdStatus = 5, stat = "Picked up - Transit to customer"},
                                new FaultModel() {IdStatus = 6, stat = "Fault Completed"},
                                
                            };
        }
    }
}