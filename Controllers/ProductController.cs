using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        MyContext db=new MyContext();
        [HttpGet]
        public IActionResult Index()
        {
            var products = db.Products.Include(e => e.Category);
            return View(products);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = db.Products.Include(e => e.Category).FirstOrDefault(e => e.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index");

            }
            return View(product);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product Product)
        {
            db.Products.Add(Product);
            db.SaveChanges();
            return RedirectToAction("Index");



        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Include(e => e.Category).FirstOrDefault(e => e.Id == id);
            if(product== null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View(product);

        }
        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            db.Products.Update(Product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var producttodelete = db.Products.Find(id);
            if (producttodelete != null)
            {
                db.Products.Remove(producttodelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
