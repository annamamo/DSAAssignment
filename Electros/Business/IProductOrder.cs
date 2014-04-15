using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Common;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductOrder" in both code and config file together.
    [ServiceContract]
    public interface IProductOrder
    {
        [OperationContract]
        void addOrder(Common.Order order);

        [OperationContract]
        void addProductOrder(Common.ProductOrder productOrder);

        [OperationContract]
        Order getOrderIDByAccountIDStatus(int accountID, string status);

        [OperationContract]
        void DeleteProductOrder(Common.ProductOrder productOrder);

        [OperationContract]
        Common.ProductOrder getProductOrderID(int productID, int orderID);

        [OperationContract]
        void UpdateProductOrder(Common.ProductOrder po);

        [OperationContract]
        Common.Order getUserProductOrder(int accountID, string status);
        
        //get ProductOrder by the given orderID
        [OperationContract]
        IEnumerable<Common.ProductOrder> getProductOrderByOrderID(int orderID);

        //to delete product order by given productId and
        [OperationContract]
        void DeleteProductOrderByIDs(int productID, int orderID);

        //to update order status
        [OperationContract]
        void UpdateOrder(Order o);

        //get user order histroy
        [OperationContract]
        List<Common.Order> getShippedOrders(int accountID);

        //get products under warranty
        [OperationContract]
        List<Common.Order> getPurchasesUnderWarranty(int accountID);
        
        
        
        
        
        
        
        
    }
}
