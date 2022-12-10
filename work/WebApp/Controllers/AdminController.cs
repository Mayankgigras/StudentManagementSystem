using DAL.Models;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly StudentDataContext _context;
        Repository repo;
        public AdminController(StudentDataContext context)
        {
            _context = context;
            repo = new Repository(_context);
        }
        public IActionResult AdminHome()
        {
            return View();
        }

    }
}
