using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using STEM_Project.Models;
using System.Text;
using System.Security.Cryptography;


namespace STEM_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly Stem1Context DbContext;
        public AdminController(Stem1Context context)
        {
            DbContext = context;
        }  

        public IActionResult Dashboard() 
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
         
        [HttpPost]
        public IActionResult AddAdmin(User addmin)
        {

            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                addmin.Password = HashPassword(addmin.Password);
                addmin.Type = "admin";
                DbContext.Users.Add(addmin);
                DbContext.SaveChanges();
                return RedirectToAction("AdminResult", "Admin");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AdminResult()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            List<User> admins = new List<User>();

            admins = DbContext.Users.Where(u => u.Type == "admin").ToList();

            return View("AdminResult", admins);
        }
        [HttpGet]
        public IActionResult StudentResult()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            List<User> std = new List<User>();

            std = DbContext.Users.Where(u => u.Type == "student").ToList();

            return View("StudentResult", std);
        }
        [HttpGet]
        public IActionResult TeacherResult()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            List<User> t = new List<User>();
        

            t = DbContext.Users.Where(u => u.Type == "teacher").ToList();

            return View("TeacherResult", t);
        }
        [HttpGet]
        public IActionResult ParentResult()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            List<User> p = new List<User>();

            p = DbContext.Users.Where(u => u.Type == "parent").ToList();

            return View("ParentResult", p);
        }
        public IActionResult RemoveAdmin(int id)
        {

            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var adminToRemove = DbContext.Users.FirstOrDefault(admin => admin.Id == id);

            if (id == 2)
            {
                TempData["Deny"] = "Access Denied";
                return RedirectToAction( "AdminResult", "Admin");
            }
            if (adminToRemove != null)
            {

                DbContext.Users.Remove(adminToRemove);
                DbContext.SaveChanges();
            }
           
            return RedirectToAction("AdminResult", "Admin"); 
        }
        public IActionResult Feedbacks()
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var feedbacks = DbContext.Feedbacks.Include(f => f.User).ToList();

            return View(feedbacks);
        }

        public IActionResult RemoveFeedback(int id)
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var feedback2remove = DbContext.Feedbacks.FirstOrDefault(f => f.Id == id);

            if (feedback2remove != null)
            {

                DbContext.Feedbacks.Remove(feedback2remove);
                DbContext.SaveChanges();
            }
            return RedirectToAction("Feedbacks","Admin");
        }
        public IActionResult DisplayFeedback(int id)
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var feedback2display = DbContext.Feedbacks.FirstOrDefault(f => f.Id == id);

            if (feedback2display != null)
            {
                feedback2display.Visible = true;
                DbContext.SaveChanges();
            }
            return RedirectToAction("Feedbacks", "Admin");
        }
        public IActionResult HideFeedback(int id)
        {
            var role = HttpContext.Session.GetString("Type");

            if (role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }
            var feedback2hide = DbContext.Feedbacks.FirstOrDefault(f => f.Id == id);

            if (feedback2hide != null)
            {
                feedback2hide.Visible = false;
                DbContext.SaveChanges();
            }
            return RedirectToAction("Feedbacks", "Admin");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
    
    //[HttpGet]
    //public IActionResult RemoveAdmin(string adminId)
    //{
    //    // Display a confirmation view with the details of the admin to be removed
    //    var adminToRemove = DbContext.Admins.FirstOrDefault(admin => admin.ID == adminId);
    //    return View(adminToRemove);
    //}


}

