using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STEM_Project.Models;
using System.Diagnostics;
using System.Linq;

namespace STEM_Project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Stem1Context _dbContext;

    public HomeController(ILogger<HomeController> logger, Stem1Context dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        // Fetch feedback data from the database
        var feedbacks = _dbContext.Feedbacks
        .Include(f => f.User) // Include the User navigation property
        .ToList();
        // Pass feedback data to the view
        return View(feedbacks);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }
    public IActionResult Levels()
    {
        int? userId = HttpContext.Session.GetInt32("Id");

        if (userId == null)
        {
            return RedirectToAction("UserLogin", "Login");
        }

        return View();
    }
    public IActionResult Actions(string p1, string p2)
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
