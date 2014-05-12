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
        /// <summary>
        /// This method is used to get a list of all the products stored in the database
        /// </summary>
        /// <returns>This method returns a list of type Products</returns>
        public IEnumerable<Common.Product> GetAllProducts()
        {
            return new DAProduct().GetAllProducts();
        }

        /// <summary>
        /// This method is used to get a product by the given productID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the productID</param>
        /// <returns>This method return a record of type Product</returns>
        public Common.Product GetProductByID(int id)
        {
            return new DAProduct().GetProductByID(id);
        }

        /// <summary>
        /// This method is used to get a list of all the comments stored in the database
        /// </summary>
        /// <returns>This method returns a list of tyoe Comment</returns>
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

        /// <summary>
        /// This method is used to get a list of Comment by the given product ID
        /// </summary>
        /// <param name="id">This parameter is of type int and holds the productID</param>
        /// <returns>This methods returns a list of type Comment</returns>
        public IEnumerable<Comment> GetCommentByProductID(int id)
        {
            return new DAComment().GetCommentByProductID(id);
        }

        /// <summary>
        /// This method is used to create a Comment and to store it into the database
        /// </summary>
        /// <param name="comment">This parameter is of type Comment and holds all the details that 
        /// need to be stored</param>
        public void Create(Comment comment)
        {
             new DAComment().Create(comment);
        }

        /// <summary>
        /// This method is used to get a list of Orders depending on the given parameters
        /// </summary>
        /// <param name="accountID">This parameter is of type int and holds the user's account ID</param>
        /// <param name="dateFrom">This parameter is of type DateTime and holds the from date</param>
        /// <param name="dateTo">This parameter is of type DateTime and holds the to date</param>
        /// <returns>This method return a list of type Order</returns>
        public IEnumerable<Order> getPurchasesByDates(int accountID, DateTime dateFrom, DateTime dateTo)
        {
            return new DAOrder().getPurchasesByDates(accountID, dateFrom, dateTo);
        }

        /// <summary>
        /// This method is used to get a list of products by the category name
        /// </summary>
        /// <param name="category">This parameter is of type string and holds the category name</param>
        /// <returns>This method returns a list of type Product</returns>
        public IEnumerable<Product> searchByCategory(string category)
        {
            return new DAProduct().searchByCategory(category);
        }

        /// <summary>
        /// This method is used to get a list of products by the product's name
        /// </summary>
        /// <param name="name">This parameter is of type string and holds the product's name</param>
        /// <returns>This method returns a list of type Product</returns>
        public IEnumerable<Product> searchByName(string name)
        {
            return new DAProduct().searchByName(name);
        }

        /// <summary>
        /// This method is used to get a list of products by a price range
        /// </summary>
        /// <param name="lowPrice">This parameter is of type decimal and holds the lowest price</param>
        /// <param name="highPrice">This parameter is of type decimal and holds the highest price</param>
        /// <returns>This method returns a list of type Product</returns>
        public IEnumerable<Product> searchByPriceRange(decimal lowPrice, decimal highPrice)
        {
            return new DAProduct().searchByPriceRange(lowPrice, highPrice);
        }

        /// <summary>
        /// This method is used to sort the list of Product by price in ascending order
        /// </summary>
        /// <returns>This method returns a sorted list of type Products</returns>
        public IEnumerable<Product> sortByAscPrice()
        {
            return new DAProduct().sortByAscPrice();
        }

        /// <summary>
        /// This method is used to sort the list of Product by price in descending order
        /// </summary>
        /// <returns>This method returns a sorted list of type Products</returns>
        public IEnumerable<Product> sortByDescPrice()
        {
            return new DAProduct().sortByDescPrice();
        }

        /// <summary>
        /// This method is used to sort the list of Products by the date Listed
        /// </summary>
        /// <returns>This method returns a sorted list of type Product</returns>
        public IEnumerable<Product> sortByDateListed()
        {
            return new DAProduct().sortByDateListed();
        }

        /// <summary>
        /// This method is used to creat a rating
        /// </summary>
        /// <param name="rating">This parameter is of type Rating and holds all the
        /// details that need to be stored in the database</param>
        public void CreateRating(Rating rating)
        {
            new DARating().CreateRating(rating);
        }

        /// <summary>
        /// This method is used to calcuate the average rating of a product
        /// </summary>
        /// <param name="productID">This parameter is of type int and holds the productID</param>
        /// <returns>This method returns a value of type double</returns>
        public double getAverageRating(int productID)
        {
            return new DARating().getAverageRating(productID);
        }

        /// <summary>
        /// This method is used to get a list of the highly rated item that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type Rating</returns>
        public IEnumerable<Rating> getHighlyRatedItem()
        {
            return new DAProduct().getHighlyRatedItem();
        }

        /// <summary>
        /// This method is used to get a list of the most purchased item that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type ProductOrder</returns>
        public IEnumerable<Common.ProductOrder> getMostPurchasedItem()
        {
            return new DAProduct().getMostPurchasedItem();
        }

        /// <summary>
        /// This method is used to get a list of the product that has the most faults that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type FaultReport</returns>
        public IEnumerable<FaultReport> getMostFaults()
        {
            return new DAProduct().getMostFaults();
        }

        /// <summary>
        /// This method is used to get a list of the product that has the least faults that exists in the database
        /// </summary>
        /// <returns>This method returns a list of type FaultReport</returns>
        public IEnumerable<FaultReport> getLeastFaults()
        {
            return new DAProduct().getLeastFaults();
        }

        /// <summary>
        /// This method is used to update the stock in a Product
        /// </summary>
        /// <param name="p">This parameter is of type Product and holds the information that needs to be updated</param>
        public void Update(Product p)
        {
            new DAProduct().Update(p);
        }

        /// <summary>
        /// This method is used to update the product's Stock
        /// </summary>
        /// <param name="newStock">This parameter is of type int and holds the new quantity of stock</param>
        /// <param name="productID">This parameter is of type int and holds the product ID</param>
        public void UpdateProductStock(int newStock, int productID)
        {
            new DAProduct().UpdateProductStock(newStock, productID);
        }
    }
}
