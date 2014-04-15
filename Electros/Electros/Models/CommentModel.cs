using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.Web.Mvc;

namespace Electros.Models
{
    public class CommentModel
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public int ProductID { get; set; }
        public int AccountID { get; set; }

        public SelectList  ProductList { get; set; }
        public virtual Product myProduct { get; set; }

        public CommentModel()
        {
            List<bool> myList = new List<bool>();
            myList.Add(true);
            myList.Add(false);


            //myComment = new SelectList(new TownServ.TownServiceClient().GetAllTowns(), "ID", "Name");
            ProductList = new SelectList(new ProductServ.ProductServiceClient().GetAllProducts(), "ID", "Name");
        }
    }
}