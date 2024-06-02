using Microsoft.AspNetCore.Mvc;
using STEM_Project.Models;
using STEM_Project.ViewModels;
using System.Security.Cryptography;
using System;
using System.Text;
namespace STEM_Project.Controllers
{
    public class SignUpController : Controller
    {
        private readonly Stem1Context _context;

        public SignUpController(Stem1Context context)
        {
            _context = context;
        }

        public ActionResult RegisterStudent()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStudent(User model)
        {

            var isEmailExist = _context.Users.Any(x => x.Email == model.Email);
            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "Email is already exists");
                return View(model);
            }
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Age = model.Age,
                College = model.College,
                EducationalLevel = model.EducationalLevel,
                Department = model.Department,
                Government = model.Government,
                /* SpecializationSubject = model.SpecializationSubject,
                 Workplace = model.Workplace,*/
                Type = "student",
                Major = model.Major,
                Password = HashPassword(model.Password)

            };

            _context.Users.Add(user);
            _context.SaveChanges();


            return RedirectToAction("UserLogin", "Login");

        }




        public ActionResult RegisterTeacher()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterTeacher(User model)
        {
            var isEmailExist = _context.Users.Any(x => x.Email == model.Email);
            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "Email is already exists");
                return View(model);
            }
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Age = model.Age,
                Government = model.Government,
                SpecializationSubject = model.SpecializationSubject,
                Workplace = model.Workplace,
                Type = "teacher",
                Password = HashPassword(model.Password),

            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("UserLogin", "Login");

        }

        public ActionResult RegisterParent()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterParent(User model)
        {
            var isEmailExist = _context.Users.Any(x => x.Email == model.Email);
            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "Email is already exists");
                return View(model);
            }
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Government = model.Government,
                Password = HashPassword(model.Password),
                Age = model.Age,
                Type = "parent"
            };

            _context.Users.Add(user);
            _context.SaveChanges();


            return RedirectToAction("UserLogin","Login");

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
}
