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

        public Town myTown { get; set; }
        

        //USer
        [Required(ErrorMessage = "The Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Surname is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Residance name is required")]
        public string ResidanceName { get; set; }

        [Required(ErrorMessage = "The Street name is required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "The mobile is required")]
        public int Mobile { get; set; }

        //Account
        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The PIN is required")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN is not valid")]
        public int PIN { get; set; }

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