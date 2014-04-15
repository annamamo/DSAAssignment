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

        public ActionResult Create()
        {
            return View(new Models.CommentModel());
        }

        [HttpPost]
        public ActionResult Create(CommentModel cm)
        {

            //check that user bought the product first
            string username = Session["username"].ToString();
            Account a = new AccountServ.AccountServiceClient().getAccountByUsername(username);
            Comment c = new Comment();
           // new EventsServ.EventsClient().Create(m.MyEvents);
            //return RedirectToAction("Index");
            //c.ID = new int();
            c.Comment1 = cm.Comment;
            //c.ProductID = Convert.ToInt32(cm.ProductList.SelectedValue);
            c.ProductID = cm.ProductID;
            c.AccountID = a.ID;
            new ProductServ.ProductServiceClient().Create(c);
            return RedirectToAction("Create");
        }

        

    }
}
