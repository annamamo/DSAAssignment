using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
namespace Electros.Controllers
{
    public class StatisticalReportController : Controller
    {
        //
        // GET: /StatisticalReport/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Report(int pid)
        {
            //highest rated item
            List<Rating> p = new ProductServ.ProductServiceClient().getHighlyRatedItem().ToList();


            Rating r = new Rating();
            Product pr = new Product();
            foreach (Rating rr in p)
            {
                r = rr;
                ViewBag.Rating = r.Rating1;
            }
            //int pID = Convert.ToInt32(r.ProductID);
            int pID = Convert.ToInt32(pid);
            pr = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return new RazorPDF.PdfResult(pr,"Report");
            //return View();
        }

        public PartialViewResult HighlyRatedItem()
        {
            List<Rating> p = new ProductServ.ProductServiceClient().getHighlyRatedItem().ToList();
            

            Rating r = new Rating();
            Product pr = new Product();
            foreach (Rating rr in p)
            {
                r = rr;
                ViewBag.Rating = r.Rating1;
            }
            int pID = Convert.ToInt32(r.ProductID);
            pr = new ProductServ.ProductServiceClient().GetProductByID(pID);
            
            return PartialView("_highlyRatedItem",pr);
            //return new RazorPDF.PdfResult("ShowReport",pr.ToString());
        }

        public ActionResult Report2(int pid)
        {
            //most purchase item
            List<ProductOrder> poList = new ProductServ.ProductServiceClient().getMostPurchasedItem().ToList();
            ProductOrder po = new ProductOrder();
            Product p = new Product();
            foreach (ProductOrder poo in poList)
            {
                po = poo;
            }
            int pID = Convert.ToInt32(po.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            //return PartialView("_mostPurchasedItem", p);
            return new RazorPDF.PdfResult(p, "Report2");
            
        }
        public PartialViewResult MostPurchasedItem()
        {
            List<ProductOrder> poList = new ProductServ.ProductServiceClient().getMostPurchasedItem().ToList();
            ProductOrder po = new ProductOrder();
            Product p = new Product();
            foreach (ProductOrder poo in poList)
            {
                po = poo;
            }
            int pID = Convert.ToInt32(po.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return PartialView("_mostPurchasedItem",p);
        }

        public ActionResult Report3(int pid)
        {
            List<FaultReport> frList = new ProductServ.ProductServiceClient().getMostFaults().ToList();
            FaultReport fr = new FaultReport();
            Product p = new Product();
            foreach (FaultReport frr in frList)
            {
                fr = frr;
            }
            int pID = Convert.ToInt32(fr.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return new RazorPDF.PdfResult(p, "Report3");
        }
        public PartialViewResult MostFaults()
        {
            List<FaultReport> frList = new ProductServ.ProductServiceClient().getMostFaults().ToList();
            FaultReport fr = new FaultReport();
            Product p = new Product();
            foreach (FaultReport frr in frList)
            {
                fr = frr;
            }
            int pID = Convert.ToInt32(fr.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return PartialView("_mostFaults", p);
        }

        public ActionResult Report4(int pid)
        {
            List<FaultReport> frList = new ProductServ.ProductServiceClient().getLeastFaults().ToList();
            FaultReport fr = new FaultReport();
            Product p = new Product();
            foreach (FaultReport frr in frList)
            {
                fr = frr;
            }
            int pID = Convert.ToInt32(fr.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return new RazorPDF.PdfResult(p, "Report4");
        }
        public PartialViewResult LeastFaults()
        {
            List<FaultReport> frList = new ProductServ.ProductServiceClient().getLeastFaults().ToList();
            FaultReport fr = new FaultReport();
            Product p = new Product();
            foreach (FaultReport frr in frList)
            {
                fr = frr;
            }
            int pID = Convert.ToInt32(fr.ProductID);
            p = new ProductServ.ProductServiceClient().GetProductByID(pID);
            return PartialView("_leastFaults", p);
        }
    }
}
