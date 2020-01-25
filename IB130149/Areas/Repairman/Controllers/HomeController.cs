using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Helper;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Areas.Repairman.Controllers
{
    [Area(nameof(Repairman))]
    [Authorization(isAdmin: false, isRepairman: true, isSeller: false, isClient: false)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}