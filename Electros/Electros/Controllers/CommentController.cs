using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Electros.Models;

namespace Electros.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/
        //DO NOT USER
        public ActionResult Create(int proID)
        {
            Product product = new ProductServ.ProductServiceClient().GetProductByID(proID);
            CommentModel model = new CommentModel();
            model.myProduct = product;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CommentModel cm, int proID)
        {
            //DO NOT USE
            //check that user bought the product first
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            Comment c = new Comment();
           // new EventsServ.EventsClient().Create(m.MyEvents);
            //return RedirectToAction("Index");
            //c.ID = new int();
            c.Comment1 = cm.Comment;
            //c.ProductID = Convert.ToInt32(cm.ProductList.SelectedValue);
            c.ProductID = proID;
            c.AccountID = a.ID;

            Rating r = new Rating();
            r.Rating1 = cm.rating;
            r.AccountID = a.ID;
            r.ProductID = proID;

            new ProductServ.ProductServiceClient().CreateRating(r);
            new ProductServ.ProductServiceClient().Create(c);
            
            return RedirectToAction("UserHistory");
        }

        

    }
}
