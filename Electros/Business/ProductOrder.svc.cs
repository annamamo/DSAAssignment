using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Data;

namespace Business
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductOrder" in code, svc and config file together.
    public class ProductOrder : IProductOrder
    {

        public void addOrder(Common.Order order)
        {
            new DAOrder().addOrder(order);
        }

        public void addProductOrder(Common.ProductOrder productOrder)
        {
            new DAProductOrder().addProductOrder(productOrder);
        }


        public Common.Order getOrderIDByAccountIDStatus(int accountID, string status)
        {
            return new DAOrder().getOrderIDByAccountIDStatus(accountID, status);
        }


        public void DeleteProductOrder(Common.ProductOrder productOrder)
        {
            new DAProductOrder().DeleteProductOrder(productOrder);
        }


        public Common.ProductOrder getProductOrderID(int productID, int orderID)
        {
            return new DAProductOrder().getProductOrderID(productID, orderID);
        }


        public void UpdateProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().UpdateProductOrder(po);
        }


        public Common.Order getUserProductOrder(int accountID, string status)
        {
            return new DAOrder().getUserProductOrder(accountID, status);
        }

        //get the productOrder by order id
        public IEnumerable<Common.ProductOrder> getProductOrderByOrderID(int orderID)
        {
            return new DAProductOrder().getProductOrderByOrderID(orderID);
        }


        public void DeleteProductOrderByIDs(int productID, int orderID)
        {
            new DAProductOrder().DeleteProductOrderByIDs(productID, orderID);
        }

        //update order status
        public void UpdateOrder(Common.Order o)
        {
            new DAOrder().UpdateOrder(o);
        }


        public List<Common.Order> getShippedOrders(int accountID)
        {
            return new DAOrder().getShippedOrders(accountID).ToList();
        }

        //get list of users bought products under warranty
        public List<Common.Order> getPurchasesUnderWarranty(int accountID)
        {
            return new DAOrder().getPurchasesUnderWarranty(accountID).ToList();
        }
    }
}
