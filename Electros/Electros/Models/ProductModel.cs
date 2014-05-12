using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.ComponentModel.DataAnnotations;

namespace Electros.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Features { get; set; }
        public int StockAmount { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string Image { get; set; }

        public List< ProductOrder> productOrderList { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }

        public Product myProduct { get; set; }

        public virtual Category myCategory { get; set; }
        public virtual Rating myRating { get; set; }
        public virtual List<Comment> myComment { get; set; }

        [Required(ErrorMessage = "The Quantity is required")]
        [Range(1, 1000)]
        public int Qty { get; set; }

        public double averageRating { get; set; }

        public ProductModel()
        {
            List<bool> myList = new List<bool>();
            myList.Add(true);
            myList.Add(false);

            //int commentID = ID;
            //if (new List<Comment>(new ProductServ.ProductServiceClient().GetCommentsByProductID(myProduct.ID)) != null && myProduct.ID != null)
            //{
                myComment = new List<Comment>(new ProductServ.ProductServiceClient().GetAllComments());
           // }
           // myComment = (List<Comment>)(new ProductServ.ProductServiceClient().GetCommentByProductID(commentID));
        }
    }
}