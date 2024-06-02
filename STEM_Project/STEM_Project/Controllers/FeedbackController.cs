using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STEM_Project.Models;
using STEM_Project.ViewModels;

namespace STEM_Project.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly Stem1Context dbContext;

        public FeedbackController(Stem1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

            return View();
        }

        [HttpPost]
        public IActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {

            int? userId = HttpContext.Session.GetInt32("Id");

            // Map the view model to your Feedback entity
            var feedback = new Feedback
            {
                Timestamp = DateTime.Now,
                UserId = userId,
                FeedbackContent = feedbackViewModel.Message,
                Rate = feedbackViewModel.Rating,
                Visible = false
            };

            // Add feedback to the database
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();

            // Redirect to thank you page
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }
            return View();
        }
    }
}
