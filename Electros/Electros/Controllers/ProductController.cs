using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;
using Electros.ProductOrderServ;

namespace Electros.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        List<Product> products = new List<Product>();
        public ActionResult ProductList()
        {
           // List<Category> events = new CatServ.CategoryServiceClient().getCategories().ToList();
            // List<TestModel> events = new TestModel().category.ToList();
           // return View("Index", events);
            products = new ProductServ.ProductServiceClient().GetAllProducts().ToList();
            return View("ProductList", products);
        }


        //public ActionResult PDF()
        //{
        //    products = new ProductServ.ProductServiceClient().GetAllProducts().ToList();
        //    return new RazorPDF.PdfResult(products, "PDF");

        //}

        public ActionResult Filter(string category, string name, string lowPrice, string highPrice)
        {
            decimal parsed ;
            try
            {
                //to check type of price
                //if ((category == null || category == "") && (name == null || name == "") && Decimal.TryParse(lowPrice, out parsed) && Decimal.TryParse(highPrice, out parsed)  )
               
                if (!Decimal.TryParse(lowPrice, out parsed) && !Decimal.TryParse(highPrice, out parsed)  )
                {
                    List<Product> pro = new ProductServ.ProductServiceClient().GetAllProducts().ToList();
                    TempData["Error"] = "Price needs to be of type decimal (2.00)";
                    return View("ProductList", pro);
                }
                //to check for nulls
                if ((category == null || category == "") && (name == null || name == "") && (lowPrice == null || lowPrice == "") && (highPrice == null || highPrice == ""))
                {
                    TempData["Null"] = "One of the values is required";
                   // return View("ProductList", products);
                }

                if ((category != null || category != "") && (name == null || name == "") && (lowPrice == null || lowPrice == "") && (highPrice == null || highPrice == ""))
                {
                    products = new ProductServ.ProductServiceClient().searchByCategory(category).ToList();
                }
                else if ((category == null || category == "") && (name != null || name != "") && (lowPrice == null || lowPrice == "") && (highPrice == null || highPrice == ""))
                {
                    products = new ProductServ.ProductServiceClient().searchByName(name).ToList();
                }
                else if ((category == null || category == "") && (name == null || name == "") && (lowPrice != null || lowPrice != "") && (highPrice != null || highPrice != ""))
                {
                    decimal lPrice = Convert.ToDecimal(lowPrice);
                    decimal hPrice = Convert.ToDecimal(highPrice);
                    products = new ProductServ.ProductServiceClient().searchByPriceRange(lPrice, hPrice).ToList();
                }
                return View("ProductList", products);
            }
            catch (Exception ex)
            {
                TempData["CatchError"] = "An error was encountered. Please try again later";
                return View("ProductList", products);
            }
        }

        public ActionResult SortByHighPrice()
        {
            products = new ProductServ.ProductServiceClient().sortByDescPrice().ToList();
            return View("ProductList", products);
        }

        public ActionResult SortByLowPrice()
        {
            products = new ProductServ.ProductServiceClient().sortByAscPrice().ToList();
            return View("ProductList", products);
        }

        public ActionResult SortByDate()
        {
            products = new ProductServ.ProductServiceClient().sortByDateListed().ToList();
            return View("ProductList", products);
        }
        //[Authorize(Roles = "Admin")]
       // [Authorize(Roles = "Admin, User")]
        public ActionResult Details(int id)
        {
             Product p = new ProductServ.ProductServiceClient().GetProductByID(id);
             IEnumerable<Comment> c = new ProductServ.ProductServiceClient().GetCommentByProductID(id);
             double avgRating = new ProductServ.ProductServiceClient().getAverageRating(id);
             ProductModel model = new ProductModel();
             model.myProduct = p;
             model.myComment = c.ToList();
             model.averageRating = avgRating;
            return View(model);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public ActionResult AddToCart(ProductModel p)
        {
            try
            {
                if (p.Qty <= 0 || p.Qty.Equals(""))
                {
                    TempData["ErrorMsg"] = "Quantity cannot be less than zero or empty";
                    Product pro = new ProductServ.ProductServiceClient().GetProductByID(p.myProduct.ID);
                    double avgRating = new ProductServ.ProductServiceClient().getAverageRating(p.myProduct.ID);
                    ProductModel pm = new ProductModel();
                    pm.myProduct = pro;
                    pm.averageRating = avgRating;
                    return View("Details", pm);

                }
                Product product = new ProductServ.ProductServiceClient().GetProductByID(p.myProduct.ID);
                int stock = Convert.ToInt32(product.StockAmount);
                string username = Session["username"].ToString();
                Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
                int accountID = a.ID;

                Order check = new ProductOrderClient().getOrderIDByAccountIDStatus(accountID, "Ordered");
                if (p.Qty <= stock)
                {
                    if (check == null)
                    {

                        Order newOrder = new Order();
                        //newOrder.ID = new int();
                        newOrder.DateOfPurchase = System.DateTime.Today;
                        newOrder.WarrantyExpiryDate = System.DateTime.Today.AddYears(2);
                        newOrder.Status = "Ordered";
                        newOrder.AccountID = accountID;
                        new ProductOrderServ.ProductOrderClient().addOrder(newOrder);

                        Order details = new ProductOrderServ.ProductOrderClient().getOrderIDByAccountIDStatus(accountID, newOrder.Status);

                        ProductOrder newProductOrder = new ProductOrder();
                        newProductOrder.OrderID = details.ID;
                        newProductOrder.ProductID = p.myProduct.ID;
                        newProductOrder.Quantity = p.Qty;

                        new ProductOrderServ.ProductOrderClient().addProductOrder(newProductOrder);
                        //return RedirectToAction("Details");

                    }
                    else if (check != null)
                    {
                        ProductOrder checkpo = new ProductOrderServ.ProductOrderClient().getProductOrderID(p.myProduct.ID, check.ID);

                        if (checkpo == null)
                        {

                            Order details = new ProductOrderServ.ProductOrderClient().getOrderIDByAccountIDStatus(accountID, "Ordered");

                            ProductOrder newProductOrder = new ProductOrder();
                            newProductOrder.OrderID = details.ID;
                            newProductOrder.ProductID = p.myProduct.ID;
                            newProductOrder.Quantity = p.Qty;

                            new ProductOrderServ.ProductOrderClient().addProductOrder(newProductOrder);
                        }
                        else if (checkpo != null)
                        {
                            ProductOrder newProductOrder = checkpo;
                            //newProductOrder.Quantity = checkpo.Quantity + p.Qty;
                            int newQty = Convert.ToInt32(checkpo.Quantity) + p.Qty;

                            // new ProductOrderServ.ProductOrderClient().UpdateProductOrder(newProductOrder);
                            new ProductOrderServ.ProductOrderClient().UpdateQtyProduct(newQty, checkpo.ProductID, checkpo.OrderID);
                        }

                    }



                }
                else if (p.Qty > stock)
                {
                    @TempData["OutOfStock"] = "The selected Item is out of stock, try again later";
                    //return RedirectToAction("ProductList");
                    Product pro = new ProductServ.ProductServiceClient().GetProductByID(p.myProduct.ID);
                    double avgRating = new ProductServ.ProductServiceClient().getAverageRating(p.myProduct.ID);
                    ProductModel m = new ProductModel();
                    m.myProduct = pro;
                    m.averageRating = avgRating;
                    return View("Details", m);
                }
                return RedirectToAction("ProductList");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "An error has occurred. Please try again later";
                Product pro = new ProductServ.ProductServiceClient().GetProductByID(p.myProduct.ID);
                double avgRating = new ProductServ.ProductServiceClient().getAverageRating(p.myProduct.ID);
                ProductModel m = new ProductModel();
                m.myProduct = pro;
                m.averageRating = avgRating;
                return View("Details", m);
            }
         }
    }
}
