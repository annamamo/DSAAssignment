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

        public ActionResult ProductList()
        {
           // List<Category> events = new CatServ.CategoryServiceClient().getCategories().ToList();
            // List<TestModel> events = new TestModel().category.ToList();
           // return View("Index", events);
            List<Product> products = new ProductServ.ProductServiceClient().GetAllProducts().ToList();
            return View("ProductList", products);
        }

        public ActionResult Details(int id)
        {
             Product p = new ProductServ.ProductServiceClient().GetProductByID(id);
             IEnumerable<Comment> c = new ProductServ.ProductServiceClient().GetCommentByProductID(id);
            
             ProductModel model = new ProductModel();
             model.myProduct = p;
             model.myComment = c.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddToCart(ProductModel p)
        {

            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order check = new ProductOrderClient().getOrderIDByAccountIDStatus(accountID, "Ordered");
             
            if(check == null)
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
            else if(check != null)
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
                    newProductOrder.Quantity = checkpo.Quantity+ p.Qty;

                    new ProductOrderServ.ProductOrderClient().UpdateProductOrder(newProductOrder);
                }

            }
            return RedirectToAction("ProductList");
            
         }
    }
}
