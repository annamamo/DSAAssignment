using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Electros.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "The Username is required")]
        public string username { get; set; }

        [Required(ErrorMessage = "The token is required")]
        public string token { get; set; }

        [Required(ErrorMessage = "The PIN is required")]
        public int pin { get; set; }
    }
}