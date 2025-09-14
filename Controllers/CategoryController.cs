using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Context;
using Project.Models;

namespace Project.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db=new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            var categories= db.Categories;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Details(int id )
        {
            var category = db.Categories.Find(id);
            if(category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);

        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        { 
        var categorytoupdate= db.Categories.Find(id);
            if (categorytoupdate == null)
            {
                return RedirectToAction("Index");

            }
            return View(categorytoupdate);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
            return RedirectToAction("Index");
           

        }
        public IActionResult Delete(int id)
        {
            var categorytodelete = db.Categories.Find(id);
            if( categorytodelete == null)
            {
                return RedirectToAction("Index");
            }
            db.Categories.Remove(categorytodelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
