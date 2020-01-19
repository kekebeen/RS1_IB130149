using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Helper;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Areas.Client.Controllers
{
    [Area(nameof(Client))]
    [Route("portal/client/[controller]")]
    [Authorization(isAdmin: true, isRepairman: false, isSeller: false, isClient: true)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}