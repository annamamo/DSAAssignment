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
        /// <summary>
        /// This method is used to create a new record of type Order
        /// </summary>
        /// <param name="order">This parameter is of type Order and holds all the details that need
        /// to be stored into the database relating to the Order</param>
        public void addOrder(Common.Order order)
        {
            new DAOrder().addOrder(order);
        }

        /// <summary>
        /// This method is used to create a new record of type ProductOrder
        /// </summary>
        /// <param name="productOrder">This parameter is of type ProductOrder and holds all the details that
        /// need to be stored into the database relating to the Product Order</param>
        public void addProductOrder(Common.ProductOrder productOrder)
        {
            new DAProductOrder().addProductOrder(productOrder);
        }

        /// <summary>
        /// This method is used to return a record of type Order by the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of tyoe int and holds the user's accountID</param>
        /// <param name="status">This parameter is of type string and holds the status of the order</param>
        /// <returns>This method returns a record of type Order</returns>
        public Common.Order getOrderIDByAccountIDStatus(int accountID, string status)
        {
            return new DAOrder().getOrderIDByAccountIDStatus(accountID, status);
        }

        /// <summary>
        /// This method is used to Delete a record from the ProductOrder list
        /// </summary>
        /// <param name="productOrder">This parameter is of type Product Order and holds all the details of the
        /// record that is going to be deleted</param>
        public void DeleteProductOrder(Common.ProductOrder productOrder)
        {
            new DAProductOrder().DeleteProductOrder(productOrder);
        }

        /// <summary>
        /// This method is used to get a record of type ProductORder with the given parameters
        /// </summary>
        /// <param name="productID">This parameter is of type int and holds the product ID</param>
        /// <param name="orderID">This parameter is of type int and hold the order's ID</param>
        /// <returns>This method return a record of type ProductOrder</returns>
        public Common.ProductOrder getProductOrderID(int productID, int orderID)
        {
            return new DAProductOrder().getProductOrderID(productID, orderID);
        }

        /// <summary>
        /// This method is used to update a record in the ProductORder table
        /// </summary>
        /// <param name="po">This paramter is of type ProductOrder, and holds all the details that
        /// need to be updated</param>
        public void UpdateProductOrder(Common.ProductOrder po)
        {
            new DAProductOrder().UpdateProductOrder(po);
        }

        /// <summary>
        /// This method is used to return an Order depending on the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <param name="status">This parameter is of type string and holds the current status of Order</param>
        /// <returns>This method returns a record of type Order</returns>
        public Common.Order getUserProductOrder(int accountID, string status)
        {
            return new DAOrder().getUserProductOrder(accountID, status);
        }

        /// <summary>
        /// This method is used to get a list of ProductOrder by the given parameter
        /// </summary>
        /// <param name="orderID">This parameter is of type int and holds the order ID</param>
        /// <returns>This method returns a list of ProductOrders</returns>
        public IEnumerable<Common.ProductOrder> getProductOrderByOrderID(int orderID)
        {
            return new DAProductOrder().getProductOrderByOrderID(orderID);
        }

        /// <summary>
        /// This method is used to delete a ProductORder by the given parameters
        /// </summary>
        /// <param name="productID">This parameter is of type int, and holds the product's ID</param>
        /// <param name="orderID">This parameter is of type int, and holds the order ID</param>
        public void DeleteProductOrderByIDs(int productID, int orderID)
        {
            new DAProductOrder().DeleteProductOrderByIDs(productID, orderID);
        }

        //update order status
        /// <summary>
        /// This method is used to Update an Order
        /// </summary>
        /// <param name="o">This parameter is of type ORder and holds all the details for
        /// the record to be updated</param>
        public void UpdateOrder(Common.Order o)
        {
            new DAOrder().UpdateOrder(o);
        }

        /// <summary>
        /// This method is used to get a list of type Order depending on the user's accountID
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <returns>This method returns a list of type Order</returns>
        public List<Common.Order> getShippedOrders(int accountID)
        {
            return new DAOrder().getShippedOrders(accountID).ToList();
        }

        //get list of users bought products under warranty
        /// <summary>
        /// This method is used to get a list of purchases that are still within the warranty
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <returns>This method return a list of type ORder</returns>
        public List<Common.Order> getPurchasesUnderWarranty(int accountID)
        {
            return new DAOrder().getPurchasesUnderWarranty(accountID).ToList();
        }

        /// <summary>
        /// This method is used to get an Order by the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of tyoe int, and holds the user's account ID</param>
        /// <param name="orderID">This parameter is of type int and holds the order IS</param>
        /// <returns>This method returns a record of type ORder</returns>
        public Common.Order getOrderByIDs(int accountID, int orderID)
        {
            return new DAOrder().getOrderByIDs( accountID,  orderID);
        }

        /// <summary>
        /// This method is used to update the quantity of a product
        /// </summary>
        /// <param name="qty">This parameter is of type int, and holds the new quantity of the product </param>
        /// <param name="productID">This parameter is of type int and holds the product's ID</param>
        /// <param name="orderID">This parameter is of type int and holds the Order ID</param>
        public void UpdateQtyProduct(int qty, int productID, int orderID)
        {
            new DAProductOrder().UpdateQtyProduct(qty, productID, orderID);
        }
    }
}
