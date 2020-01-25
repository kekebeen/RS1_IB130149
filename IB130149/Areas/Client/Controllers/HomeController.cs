using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Helper;
using IB130149.Models;
using IB130149.Areas.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IB130149.Context;

namespace IB130149.Areas.Client.Controllers
{
    [Area(nameof(Client))]
    [Authorization(isAdmin: false, isRepairman: false, isSeller: false, isClient: true)]
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext db)
        {
            _context = db;
        }
        public IActionResult Index()
        {
            // get logged in customer
            User customer = HttpContext.GetLoggedInuser();
            // get initial card for the latest request status
            // get recent list of customer service reuqests
            ClientIndexVm model = new ClientIndexVm();

            model.ClientServiceRequests = _context.ServiceRequest.Where(sr => sr.RequestedById == customer.Id).OrderByDescending(o => o.RequestDate).Select(y => new ServiceRequestVm
            {
                Name = y.Client.Name,
                Surname = y.Client.Surname,
                DeliveryAddress = y.DeliveryAddress,
                IncludeCustomerPickup = y.IncludeCustomerPickup,
                IncludeDelivery = y.IncludeDelivery,
                IncludeHomeService = y.IncludeHomeService,
                Status = _context.ServiceStatus
                .Where(ss => ss.Id == _context.ServiceTicket
                .Where(st => st.ServiceRequestId == y.Id)
                .Single().StatusId)
                .Single().Value ?? "In review"
            }).ToList();

            if (model.ClientServiceRequests.Count() > 0)
            {
                ServiceRequestVm latest = model.ClientServiceRequests[0];
                model.Status = latest.Status;
                model.DeliveryAddress = latest.DeliveryAddress;
            } else
            {
                model.Status = "no status available";
                model.DeliveryAddress = "No requests found.";
            }

                // return list of requests
            return View(model);
    } }
}