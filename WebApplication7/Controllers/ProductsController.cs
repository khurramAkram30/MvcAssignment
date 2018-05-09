using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        ShoppingCartEntities db = new ShoppingCartEntities();
        public ActionResult Index()
        {
            List<Product> pro = new List<Product>();

            ViewBag.product = pro.ToList();
            
            return View();

        }
        
        public ActionResult add() {

            return View();
        }

        [HttpPost]
        public ActionResult add(string name, float price, string picture, string detail, int Catid)
        {
            try
            {
                var product = new Product();

                product.Name = name;
                product.Price = price;
                product.Photo = picture;
                product.Detail = detail;
                product.CategoryId = Catid;

                db.Products.Add(product);
                db.SaveChanges();
                TempData["Message"] = "product has been added.";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                throw;
            }
            
            
        }


        public ActionResult Edit(int Id)
        {
            var prod = db.Products.Find(Id);

            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(string name, float price, string picture, string detail, int Catid)
        {

            try
            {
                var product = new Product();

                product.Name = name;
                product.Price = price;
                product.Photo = picture;
                product.Detail = detail;
                product.CategoryId = Catid;

                db.Products.Add(product);
                db.SaveChanges();
                TempData["Message"] = "product has been added.";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                throw;
            }

        }

    

     
        
    }
}