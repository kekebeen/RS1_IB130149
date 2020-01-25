using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Helper;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorization(isAdmin: true, isRepairman: false, isSeller: false, isClient: false)]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}