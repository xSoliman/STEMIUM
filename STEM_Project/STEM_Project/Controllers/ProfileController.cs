using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using STEM_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using STEM_Project.ViewModels;
namespace Visual_Project.Controllers
{
    public class ProfileController : Controller
    {
        private readonly Stem1Context dbcontext;
        private readonly IWebHostEnvironment _environment;

        public ProfileController(Stem1Context context, IWebHostEnvironment environment)
        {
            dbcontext = context;
            _environment = environment;
        }

        public IActionResult MyProfile()
        {

            var Id = HttpContext.Session.GetInt32("Id");

            if (Id == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var CurUser = (from user in dbcontext.Users
                           where user.Id == Id
                           select user).FirstOrDefault();


            return View(CurUser);
        }

        public IActionResult EditProfile()
        {
            var Id = HttpContext.Session.GetInt32("Id");

            if (Id == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var CurUser = (from user in dbcontext.Users
                           where user.Id == Id
                           select user).FirstOrDefault();


            return View(CurUser);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(User updateUser)
        {


            var Id = HttpContext.Session.GetInt32("Id");

            if (Id == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }


            var CurUser = (from user in dbcontext.Users
                           where user.Id == Id
                           select user).FirstOrDefault();

            var isEmailExist = dbcontext.Users.Any(x => x.Email == updateUser.Email);
            updateUser.Type = CurUser.Type;
            if (isEmailExist && updateUser.Email != CurUser.Email)
            {
                ModelState.AddModelError("Email", "Email is already exists");
                return View(updateUser);
            }

            if (updateUser.Name != null)
                CurUser.Name = updateUser.Name;

            if (updateUser.Email != null)
                CurUser.Email = updateUser.Email;

            if (updateUser.Age != null)
                CurUser.Age = updateUser.Age;

            if (updateUser.Government != null)
                CurUser.Government = updateUser.Government;
            if (updateUser.Type == "student")
            {
                if (updateUser.EducationalLevel != null)
                    CurUser.EducationalLevel = updateUser.EducationalLevel;
                if (updateUser.Department != null)
                    CurUser.Department = updateUser.Department;

                if (updateUser.Major != null)
                    CurUser.Major = updateUser.Major;

            }
            if (updateUser.Type == "teacher")
            {
                if (updateUser.SpecializationSubject != null)
                    CurUser.SpecializationSubject = updateUser.SpecializationSubject;

                if (updateUser.Workplace != null)
                    CurUser.Workplace = updateUser.Workplace;
            }

            dbcontext.SaveChanges();

            return RedirectToAction("MyProfile");
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public IActionResult ChangePassword()
        {
            var Id = HttpContext.Session.GetInt32("Id");

            if (Id == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }


            var CurUser = (from user in dbcontext.Users
                           where user.Id == Id
                           select user).FirstOrDefault();

            return View(CurUser);
        }
        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            var userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            var user = dbcontext.Users.FirstOrDefault(u => u.Id == userId);


            // Check if the current password matches the hashed password in the database
            var hashedCurrentPassword = HashPassword(currentPassword);

            if (hashedCurrentPassword != user.Password)
            {
                ViewBag.ErrorMessage = "Current password is incorrect";
                return View();
            }


            // Check if the new password and confirm password match
            if (newPassword != confirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match";
                return View();
            }

            // Check if the new password meets the minimum length requirement
            if (newPassword.Length < 8)
            {
                ViewData["ErrorMessage"] = "Password must be at least 8 characters long";
                return View();
            }

            // Update the user's password in the database
            user.Password = HashPassword(newPassword);
            dbcontext.SaveChanges();

            TempData["SuccessMessage"] = "Password changed successfully!";

            // Display the success message on the same page
            ViewBag.SuccessMessage = TempData["SuccessMessage"] as string;

            // Render the view with the success message
            return View();
        }
    }
}
