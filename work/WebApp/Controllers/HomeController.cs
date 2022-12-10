using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using DAL;
using DAL.Models;
using NuGet.Frameworks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDataContext _context;
        Repository repo; 
        public HomeController(StudentDataContext context)
        {
            _context = context;
            repo = new Repository(_context);
        }

        /*   private readonly ILogger<HomeController> _logger;

           public HomeController(ILogger<HomeController> logger)
           {
               _logger = logger;
           }
        */
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CheckCredentials(IFormCollection form)
        {
            string email = form["name"];
            string password = form["pwd"];
            bool result = false;
             result = repo.LoginUser(email, password);
            if (result)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
