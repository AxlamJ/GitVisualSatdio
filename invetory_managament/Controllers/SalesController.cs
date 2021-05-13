using invetory_managament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invetory_managament.Controllers
{
    public class SalesController : Controller
    {
        private invetory_managamentEntities db = new invetory_managamentEntities();

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> sales = db.Sales.OrderByDescending(x => x.Id).ToList();
            return View(sales);
        }

        [HttpGet]
        public ActionResult CreateSale()
        {
            List<string> productname = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProducName = new SelectList(productname);
            return View();
        }
        [HttpPost]
        public ActionResult CreateSale(Sale sale)
        {
            var formatDate = sale.sale_date.ToString("dd-MM-yyyy");


            sale.sale_date = Convert.ToDateTime(formatDate);
            db.Sales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult UpdateSale(int id)
        {
            Sale sale = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            return View(sale);
        }
        [HttpPost]
        public ActionResult UpdateSale(int id, Sale sale)
        {
            var formatDate = sale.sale_date.ToString("dd-MM-yyyy");


            sale.sale_date = Convert.ToDateTime(formatDate);
            Sale sa = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            sa.sale_prod = sale.sale_prod;
            sa.sale_qty = sale.sale_qty;
            sa.sale_date = sale.sale_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult DetailSales(int id)
        {
            Sale sale = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            return View(sale);
        }

        [HttpGet]

        public ActionResult DeleteSale(int id)
        {

            Sale sale = db.Sales.Where(x => x.Id == id).SingleOrDefault();
            return View(sale);
        }

        [HttpPost]
        public ActionResult DeleteSale(int id, Sale sale)
        {

            db.Sales.Remove(db.Sales.Where(x => x.Id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

    }
}