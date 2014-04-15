using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Data
{
   
    public class DAComment : ConnectionClass
    {
        public DAComment() : base() { }
       // public DAComment(ElectrosDBEntities entities) : base(entities) { }
        public void Create(Comment comment)
        {

            entities.AddToComment(comment);
            entities.SaveChanges();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            //List<Comment> allComments = new List<Comment>();
            return entities.Comment.AsEnumerable();
          // return entities.Comment.SingleOrDefault(c => c.ProductID == id);
            //return (from c in this.entities.Comment
            //        join p in this.entities.Product on c.ProductID equals p.ID

            //        select new
            //        {
            //            c.Comment1
            //        });

        }
        public IEnumerable<Comment> GetCommentByProductID(int id)
        {
            return entities.Comment.Where(c => c.ProductID == id);
        }
    }
}
