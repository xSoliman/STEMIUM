using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Cryptography;
using STEM_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using STEM_Project.ViewModels;


namespace STEM_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly Stem1Context _dbContext;

        public LoginController(Stem1Context dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult UserLogin()
        {
            HttpContext.Session.Clear();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin(LoginRequest model)
        {
            var authentUser = _dbContext.Users
               .Where(u => u.Email == model.Email)
               .FirstOrDefault();

            if (authentUser != null &&
             authentUser.Password == HashPassword(model.Password))
                {
                    HttpContext.Session.SetInt32("Id", authentUser.Id);
                    HttpContext.Session.SetString("Type", authentUser.Type);

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    TempData["Wrong"] = "Wrong Email or Password";
                    return View(model);
                }
           
          
        }

    
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
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
