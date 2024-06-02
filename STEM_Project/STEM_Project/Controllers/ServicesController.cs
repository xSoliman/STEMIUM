
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STEM_Project.Models;
using STEM_Project.ViewModels;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using STEM_Project.Migrations;
using Microsoft.AspNetCore.SignalR;

public class ServicesController : Controller
{
    private readonly IWebHostEnvironment _hostingEnvironment;

    private readonly Stem1Context db;
    public ServicesController(Stem1Context context, IWebHostEnvironment hostingEnvironment)
    {
        db = context;
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index(int lvl, string sub, int ch,int lsn)
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
            chapter = ch,
            lesson = lsn
        };
        return View(info);
    }

    public IActionResult ServiceDetails(int lvl, string sub, int ch, int lsn, string srvc)
    {
        int? userId = HttpContext.Session.GetInt32("Id");

        if (userId == null)
        {
            return RedirectToAction("UserLogin", "Login");
        }

        var services = db.Services.Where(s => s.Grade == lvl && s.ServiceType == srvc && s.Subject == sub &&s.Lesson==lsn&&s.Chapter==ch).ToList();

        var info = new Info
        {
            service = srvc,
            level = lvl,
            subject = sub,
            chapter = ch,
            lesson=lsn,
            Services = services
        };

        return View(info);
    }


    public IActionResult AddService(int lvl, string sub, int ch, int lsn, string srvc)
    {
         int? userId = HttpContext.Session.GetInt32("Id");

            if (userId == null)
            {
                return RedirectToAction("UserLogin", "Login");
            }

        var role = HttpContext.Session.GetString("Type");

        if (role != "admin")
        {
            return RedirectToAction("Index", "Home");
        }
        var info = new Info
        {
            level = lvl,
            subject = sub,
            service = srvc,
            lesson = lsn,
            chapter=ch
        };

        return View(info);
    }

    [HttpPost]
    public async Task<IActionResult> AddService(int grade, string subject, string serviceType, string serviceName, IFormFile filePath,int lsn, int ch)
    {
        int? userId = HttpContext.Session.GetInt32("Id");

        if (userId == null)
        {
            return RedirectToAction("UserLogin", "Login");
        }

        var role = HttpContext.Session.GetString("Type");

        if (role != "admin")
        {
            return RedirectToAction("Index", "Home");
        }
        if (filePath != null && filePath.Length > 0)
        {
            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "PDFs");
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filePath.FileName);
            var fileSavePath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(fileSavePath, FileMode.Create))
            {
                await filePath.CopyToAsync(fileStream);
            }

            var newService = new Services
            {
                Grade = grade,
                Subject = subject,
                ServiceType = serviceType,
                ServiceName = serviceName,
                Lesson=lsn,
                Chapter=ch,
                FilePath = Path.Combine("PDFs/", fileName)
             };

            db.Services.Add(newService);
            await db.SaveChangesAsync();
            TempData["Message"] = "Service added successfully.";

    

            return RedirectToAction("ServiceDetails", new {
                lvl = grade,
                sub = subject,
                srvc = serviceType,
                lsn = lsn,
                ch = ch
            });
        }

        ModelState.AddModelError(string.Empty, "Please select a PDF file to upload.");
        return View();
    }





    [HttpPost]
    public async Task<IActionResult> Delete(int id, int lvl, string sub, int ch, int lsn, string srvc)
    {
        int? userId = HttpContext.Session.GetInt32("Id");

        if (userId == null)
        {
            return RedirectToAction("UserLogin", "Login");
        }

        var role = HttpContext.Session.GetString("Type");

        if (role != "admin")
        {
            return RedirectToAction("Index", "Home");
        }
        var serviceToRemove = await db.Services.FindAsync(id);

        if (serviceToRemove != null)
        {
            try
            {
                // Get the absolute path of the file
                string absolutePath = Path.Combine(_hostingEnvironment.WebRootPath, serviceToRemove.FilePath);



                // Remove the service
                if (System.IO.File.Exists(absolutePath))
                {
                    System.IO.File.Delete(absolutePath);
                }

                db.Services.Remove(serviceToRemove);
                await db.SaveChangesAsync();

                // Set message in TempData
                TempData["Message"] = "Item deleted successfully";
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                TempData["ErrorMessage"] = "An error occurred while deleting the item.";
                // Optionally, return an error view or redirect to an error page
                return RedirectToAction("Error", "Home");
            }
        }
        else
        {
            TempData["ErrorMessage"] = "Service not found.";
        }

        // Redirect to ServiceDetails action with route values
        return RedirectToAction("ServiceDetails", "Services", new { lvl = lvl, sub = sub, srvc = srvc, lsn=lsn, ch=ch });
    }


}
