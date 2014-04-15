using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        IEnumerable<Product> GetAllProducts();

        [OperationContract]
        Product GetProductByID(int id);

        [OperationContract]
        IEnumerable<Comment> GetAllComments();

        [OperationContract]
         IEnumerable<Comment> GetCommentByProductID(int id);

        [OperationContract]
        void Create(Comment comment);
        
        
        
        
    }
}
