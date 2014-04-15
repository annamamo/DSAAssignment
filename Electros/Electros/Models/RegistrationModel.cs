using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Electros.Models
{
    public class RegistrationModel 
    {
        
        public User myUser { get; set; }
         
        public SelectList TownList { get; set; }
        public SelectList CountryList { get; set; }
        //set Account virtual & Role & then set into foreign key
       //[ ForeignKey("AccountID")]
       // public virtual ICollection< Account> myAccount { get; set; }
        public  virtual Account myAccount { get; set; }

       // [ForeignKey("RoleID")]
       public List<Role> myRole { get; set; }
         
       // public ICollection<List<Role>> myRole { get; set; }
        public List<CheckBoxes> roles {get; set;}

        ////[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[Required]
        //public string Password { get; set; }

        //[Required]
        //public int PIN { get; set; }

        //public override ValidationResult Validate(RegisterModel instance)
        //{
        //    var result = Validate(instance);
        //    if (string.IsNullOrEmpty(myUser.Surname))
        //    {
        //        result.Errors.Add(new ValidationResult("Username cannot be empty");
        //    }
        //}

        public class CheckBoxes
        {
            public string Text {get; set;}
            public bool Checked {get; set;}
        }

        public RegistrationModel()
        {
            List<bool> myList = new List<bool>();
            myList.Add(true);
            myList.Add(false);

            
           

            myRole = new List<Role>(new RoleServ.RoleServiceClient().GetAllRoles());
            TownList = new SelectList(new TownServ.TownServiceClient().GetAllTowns(), "ID", "Name");
            CountryList = new SelectList(new CountryServ.CountryServiceClient().GetAllCountries(), "ID", "Name");
        }
    }
}