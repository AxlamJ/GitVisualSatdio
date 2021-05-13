using invetory_managament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invetory_managament.Controllers
{
   
    public class PurchaseController : Controller
    {
       private invetory_managamentEntities db = new invetory_managamentEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> purchase = db.Purchases.OrderByDescending(x => x.Id).ToList();
            return View(purchase);
        }
        [HttpGet]
        public ActionResult CraetePurchase()
        {
            List<string> prductName = db.Products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(prductName);
            return View();
        }
        [HttpPost]
        public ActionResult CraetePurchase(Purchase purchase)
        {

            var formatDate = purchase.purchase_date.ToString("dd-MM-yyyy");

                
            purchase.purchase_date = Convert.ToDateTime(formatDate);
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult UpdatePurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            return View(purchase);
        }
        [HttpPost]
        public ActionResult UpdatePurchase(int id, Purchase purchase)
        {
            var formatDate = purchase.purchase_date.ToString("dd-MM-yyyy");


            purchase.purchase_date = Convert.ToDateTime(formatDate);
            Purchase pur = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            pur.purchase_prod = purchase.purchase_prod;
            pur.purchase_qty = purchase.purchase_qty;
            pur.purchase_date = purchase.purchase_date;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
        [HttpGet]
        public ActionResult DetailPurchase(int id)
        {
            Purchase pur = db.Purchases.Where(x => x.Id == id).SingleOrDefault();

            return View(pur);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            Purchase purchase = db.Purchases.Where(x => x.Id == id).SingleOrDefault();
            return View(purchase);
        }


        [HttpPost]
        public ActionResult DeletePurchase(int id, Purchase purchase)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.Id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

    }
}