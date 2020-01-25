using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Areas.Client.ViewModels;
using IB130149.Context;
using IB130149.Helper;
using IB130149.Models;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Areas.Client.Controllers
{
    [Area(nameof(Client))]
    [Authorization(isAdmin: false, isRepairman: false, isSeller: false, isClient: true)]
    public class ServiceController : Controller
    {
        private MyContext _ctx;

        public ServiceController(MyContext db)
        {
            _ctx = db;
        }
        
        public IActionResult New(ServiceRequestCreateVm? model)
        {
            if(ModelState.Count == 1)
            {
                ServiceRequestCreateVm obj = new ServiceRequestCreateVm();
                obj.RequestDate = DateTime.Now;
                return View(obj);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ServiceRequestCreateVm model)
        {
            // handle initial validation
            if(!ModelState.IsValid)
            {
                TempData["error_message"] = "Error creating new request. Please check your fields.";
                return View("New", model);
            }

            User currentUser = HttpContext.GetLoggedInuser();
            ServiceRequest obj = new ServiceRequest();
            obj.DeliveryAddress = model.Address;
            obj.IncludeCustomerPickup = model.IncludeCustomerPickup;
            obj.IncludeDelivery = model.IncludeDelivery;
            obj.IncludeHomeService = model.IncludeHomeService;
            obj.RequestDate = DateTime.Now;
            obj.RequestedById = currentUser.Id;
            obj.Impression = model.Impression;

            _ctx.ServiceRequest.Add(obj);
            _ctx.SaveChanges();
            TempData["success_message"] = "Service request created.";
            // redirect to main page on success
            return RedirectToAction("Index", "Home", new { area = "Client" }, null);
        }
    }
}