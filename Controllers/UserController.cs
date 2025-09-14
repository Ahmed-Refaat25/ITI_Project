using Microsoft.AspNetCore.Mvc;
using Project.Context;
using Project.Models;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(User User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
                return RedirectToAction("LogIn");
            }
            return View(User);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string email,string password)
        {
            var finduser= db.Users.FirstOrDefault(e=>e.Email==email && e.Password==password);
            if (finduser == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View();
            }
            return RedirectToAction("Index","product");
        }
       
    }
}
