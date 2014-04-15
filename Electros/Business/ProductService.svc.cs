using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    public class ProductService : IProductService
    {
        ElectrosDBEntities entities = new ElectrosDBEntities();
        public IEnumerable<Common.Product> GetAllProducts()
        {
            return new DAProduct().GetAllProducts();
        }

        public Common.Product GetProductByID(int id)
        {
            return new DAProduct().GetProductByID(id);
        }


        public IEnumerable<Comment> GetAllComments()
        {
            return new DAComment().GetAllComments();
            //IEnumerable<Comment> comments =  new DAComment().GetAllComments();
            //List<Comment> commentFiltered = new List<Comment>();
            //foreach (Comment c in comments)
            //{
            //    if (c.ProductID == id)
            //    {
            //        commentFiltered.Add(c);
            //    }
            //}

            //return commentFiltered;

        }


        public IEnumerable<Comment> GetCommentByProductID(int id)
        {
            return new DAComment().GetCommentByProductID(id);
        }


        public void Create(Comment comment)
        {
             new DAComment().Create(comment);
        }
    }
}
