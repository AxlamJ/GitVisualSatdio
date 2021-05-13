using invetory_managament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace invetory_managament.Controllers
{
    public class ProductController : Controller
    {
       private invetory_managamentEntities db = new invetory_managamentEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpGet]
        public ActionResult DisplayProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x => x.Id == id).SingleOrDefault();

            return View(pr);
        }
        [HttpPost]
        public ActionResult UpdateProduct(int id, Product product)
        {
            Product pr = db.Products.Where(x => x.Id == id).SingleOrDefault();
            pr.product_name = product.product_name;
            pr.Product_qty = product.Product_qty;
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

        [HttpGet]
        public ActionResult DetailProduct(int id)
        {
            Product product = db.Products.Where(x => x.Id == id).SingleOrDefault();
            return View(product);
        }
        [HttpGet]

        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Where(x => x.Id == id).SingleOrDefault();

            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id, Product pro)
        {

            db.Products.Remove(db.Products.Where(x => x.Id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }

    }
}