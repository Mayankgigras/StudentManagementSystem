using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using workApp.Models;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace workApp.Controllers
{
   
    public class HomeController : Controller
    {
      //  private readonly StudentDataContext _context;
        Repository repo;
        public HomeController(//StudentDataContext context
                              )
        {
           // _context = context;
            repo = new Repository();
        }
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CheckRole(IFormCollection frm)
        {
            string email = frm["email"];
            string password = frm["pwd"];
            bool roleId = repo.LoginUser(email, password);
            if (roleId == true)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else 
            {
                return View("Login");
            }
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
