using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IB130149.Models;
using IB130149.Context;
using IB130149.Helper;

namespace IB130149.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext db)
        {
            _logger = logger;
            _context = db;
        }
        [Authorization(isAdmin: true, isRepairman: true, isSeller: true, isClient: true)]
        public IActionResult Index()
        {
            //TODO: handle redirect logic here once auth is ready
            //Redirect to area controllers based on employee role
            List<User> users = _context.User.ToList();
            ViewBag.users = users;
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
    }
}
