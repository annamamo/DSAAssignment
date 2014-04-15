using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;

namespace Electros.Controllers
{
    public class BasketController : Controller
    {
        //
        // GET: /Basket/

        public ActionResult Index()
        {
            
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            if (o != null)
            {
                int orderID = o.ID;

                List<ProductOrder> productOrders = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(orderID).ToList();

                //to show totalPrice
                decimal price;
                int qty;
                decimal totalPrice = 0;
                foreach (ProductOrder i in productOrders)
                {
                    Product product = new ProductServ.ProductServiceClient().GetProductByID(i.ProductID);

                    price = Convert.ToDecimal(i.Product.Price);
                    qty = Convert.ToInt32(i.Quantity);
                    totalPrice += price * qty;
                }
                ViewData["totalPrice"] = totalPrice;
                return View("Index", productOrders);
            }
            else {
                return View("Index",new List<ProductOrder>());
            }
        }

       
        public ActionResult Delete(int productID)
        {
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            int orderID = o.ID;

            new ProductOrderServ.ProductOrderClient().DeleteProductOrderByIDs(productID, orderID);
            return RedirectToAction("Index");
        }

        public ActionResult Checkout()
        {
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Order o = new ProductOrderServ.ProductOrderClient().getUserProductOrder(accountID, "Ordered");
            int orderID = o.ID;
            o.Status = "Shipped";
            new ProductOrderServ.ProductOrderClient().UpdateOrder(o);
            return RedirectToAction("ProductList", "Product");
        }

        public ActionResult UserHistory()
        {
            List<ProductOrder> productOrders = new List<ProductOrder>();

            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            List<Order> ordersList = new ProductOrderServ.ProductOrderClient().getShippedOrders(accountID).ToList();
            


            foreach (Order i in ordersList)
            { 
                List<ProductOrder> po = new ProductOrderServ.ProductOrderClient().getProductOrderByOrderID(i.ID).ToList();

                foreach (ProductOrder p in po)
                {
                    productOrders.Add(p);
                }
            }
            return View("UserHistory",productOrders);
        }

        public ActionResult PostComment(int productID)
        {
            Product p = new ProductServ.ProductServiceClient().GetProductByID(productID);
            CommentModel model = new CommentModel();
            model.myProduct = p;
            return View(model);
        }

        [HttpPost]
        public ActionResult PostComment(CommentModel cm, int productID)
        {
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            int accountID = a.ID;

            Comment c = new Comment();
            c.Comment1 = cm.Comment;
            c.ProductID = cm.ProductID;
            c.AccountID = accountID;

            new ProductServ.ProductServiceClient().Create(c);
            return RedirectToAction("UserHistory");
        }

        public ActionResult Details(int pid, int oid)
        {
            ProductOrder po = new ProductOrderServ.ProductOrderClient().getProductOrderID(pid, oid);
            //Product p = new ProductServ.ProductServiceClient().GetProductByID(id);

            
           
            return View("Details",po);
        }

        //[HttpPost]
        //public ViewResult AddComment()
        //{

        //    string username = Session["username"].ToString();
        //    Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
        //    int accountID = a.ID;

        //    Comment c = new Comment();
        //    c.Comment1 = 

        //    //for comment
        //   // new ProductServ.ProductServiceClient().Create(c);
        //    return View();
        //}
    }
}
