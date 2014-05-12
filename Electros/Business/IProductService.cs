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
        /// <summary>
        /// This method is used to get a list of all the products stored in the database
        /// </summary>
        /// <returns>This method returns a list of type Products</returns>
        [OperationContract]
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// This method is used to get a product by the given productID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the productID</param>
        /// <returns>This method return a record of type Product</returns>
        [OperationContract]
        Product GetProductByID(int id);

        /// <summary>
        /// This method is used to get a list of all the comments stored in the database
        /// </summary>
        /// <returns>This method returns a list of tyoe Comment</returns>
        [OperationContract]
        IEnumerable<Comment> GetAllComments();

        /// <summary>
        /// This method is used to get a list of Comment by the given product ID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the productID</param>
        /// <returns>This methods returns a list of type Comment</returns>
        [OperationContract]
         IEnumerable<Comment> GetCommentByProductID(int id);

        /// <summary>
        /// This method is used to create a Comment and to store it into the database
        /// </summary>
        /// <param name="comment">This parameter is of type Comment and holds all the details that 
        /// need to be stored</param>
        [OperationContract]
        void Create(Comment comment);

        /// <summary>
        /// This method is used to get a list of Orders depending on the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to date</param>
        /// <returns>This method return a list of type Order</returns>
        [OperationContract]
        IEnumerable<Common.Order> getPurchasesByDates(int accountID, DateTime dateFrom, DateTime dateTo);
        
        //search product by category
        /// <summary>
        /// This method is used to get a list of products by the category name
        /// </summary>
        /// <param name="category">This parameter is of type string and holds the category name</param>
        /// <returns>This method returns a list of type Product</returns>
        [OperationContract]
        IEnumerable<Common.Product> searchByCategory(string category);
        
        //search product by name
        /// <summary>
        /// This method is used to get a list of products by the product's name
        /// </summary>
        /// <param name="name">This parameter is of type string and holds the product's name</param>
        /// <returns>This method returns a list of type Product</returns>
        [OperationContract]
        IEnumerable<Common.Product> searchByName(string name);

        //search product by price
        /// <summary>
        /// This method is used to get a list of products by a price range
        /// </summary>
        /// <param name="lowPrice">This parameter is of type decimal and holds the lowest price</param>
        /// <param name="highPrice">This parameter is of type decimal and holds the highest price</param>
        /// <returns>This method returns a list of type Product</returns>
        [OperationContract]
        IEnumerable<Common.Product> searchByPriceRange(decimal lowPrice, decimal highPrice);

        //sort produclist by price ascending
        /// <summary>
        /// This method is used to sort the list of Product by price in ascending order
        /// </summary>
        /// <returns>This method returns a sorted list of type Products</returns>
        [OperationContract]
        IEnumerable<Common.Product> sortByAscPrice();
        
        //sort productlist by price descending
        /// <summary>
        /// This method is used to sort the list of Product by price in descending order
        /// </summary>
        /// <returns>This method returns a sorted list of type Products</returns>
        [OperationContract]
        IEnumerable<Common.Product> sortByDescPrice();
        
        //sort productlist by datelisted
        /// <summary>
        /// This method is used to sort the list of Products by the date Listed
        /// </summary>
        /// <returns>This method returns a sorted list of type Product</returns>
        [OperationContract]
        IEnumerable<Common.Product> sortByDateListed();

        //add rating
        /// <summary>
        /// This method is used to creat a rating
        /// </summary>
        /// <param name="rating">This parameter is of type Rating and holds all the
        /// details that need to be stored in the database</param>
        [OperationContract]
        void CreateRating(Common.Rating rating);
        
        //get average rating
        /// <summary>
        /// This method is used to calcuate the average rating of a product
        /// </summary>
        /// <param name="productID">This parameter is of type int and holds the productID</param>
        /// <returns>This method returns a value of type double</returns>
        [OperationContract]
        double getAverageRating(int productID);

        //report 1
        /// <summary>
        /// This method is used to get a list of the highly rated item that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type Rating</returns>
        [OperationContract]
        IEnumerable<Common.Rating> getHighlyRatedItem();

        //report 2
        /// <summary>
        /// This method is used to get a list of the most purchased item that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type ProductOrder</returns>
        [OperationContract]
        IEnumerable<Common.ProductOrder> getMostPurchasedItem();

        //report 3
        /// <summary>
        /// This method is used to get a list of the product that has the most faults that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type FaultReport</returns>
        [OperationContract]
        IEnumerable<Common.FaultReport> getMostFaults();

        //report 4
        /// <summary>
        /// This method is used to get a list of the product that has the least faults that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type FaultReport</returns>
        [OperationContract]
        IEnumerable<Common.FaultReport> getLeastFaults();

        //reduce stock
        /// <summary>
        /// This method is used to update the stock in a Product
        /// </summary>
        /// <param name="p">This parameter is of type Product and holds the information that needs to be updated</param>
        [OperationContract]
        void Update(Common.Product p);

        /// <summary>
        /// This method is used to update the product's Stock
        /// </summary>
        /// <param name="newStock">This parameter is of type int and holds the new quantity of stock</param>
        /// <param name="productID">This parameter is of type int and holds the product ID</param>
        [OperationContract]
        void UpdateProductStock(int newStock, int productID);
       
    }
}
