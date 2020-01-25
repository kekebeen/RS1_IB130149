using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Helper;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Areas.Seller.Controllers
{
    [Area(nameof(Seller))]
    [Authorization(isAdmin: false, isRepairman: false, isSeller: true, isClient: false)]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}