using IB130149.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IB130149.Components
{
    public class Badge : ViewComponent
    {
        public IViewComponentResult Invoke(string status)
        {
            return View(new BadgeComponentVm { 
                status = status
            });
        }
    }
}
