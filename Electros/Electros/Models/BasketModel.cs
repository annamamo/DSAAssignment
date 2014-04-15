using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace Electros.Models
{
    public class BasketModel
    {
        public Order myOrder { get; set; }
        public ProductOrder myProductOrder { get; set; }
    }
}