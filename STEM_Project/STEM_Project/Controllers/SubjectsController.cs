using Microsoft.AspNetCore.Mvc;
using STEM_Project.ViewModels;

namespace STEM_Project.Controllers
{
    public class SubjectsController : Controller
    {
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            return View();
        }
          public IActionResult Subjects(int lvl)
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var info = new Info
            {
                level = lvl
            };
            return View(info);
        }
        public IActionResult Chapters(int lvl, string sub)
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var info = new Info
            {
                level = lvl,
                subject = sub
            };
            return View(info);
        }
        public IActionResult Lessons(int lvl, string sub,int ch)
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var info = new Info
            {
                level = lvl,
                subject = sub,
                chapter = ch
            };
            return View(info);
        }

    }
}
