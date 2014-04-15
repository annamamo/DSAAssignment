using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Electros.Models
{
    public class LoginModel
    {
        public string username { get; set; }
        public string token { get; set; }
        public int pin { get; set; }
    }
}