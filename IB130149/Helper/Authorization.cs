using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IB130149.Models;
using IB130149.Context;

namespace IB130149.Helper
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(bool isAdmin, bool isRepairman, bool isSeller, bool isClient) : base (typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { isAdmin, isRepairman, isSeller, isClient };
        }
    }

    public class MyAuthorizeImpl: IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool admin, bool repairman, bool seller, bool client)
        {
            _admin = admin;
            _repairman = repairman;
            _seller = seller;
            _client = client;
        }

        private readonly bool _admin;
        private readonly bool _repairman;
        private readonly bool _seller;
        private readonly bool _client;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            User user = filterContext.HttpContext.GetLoggedInuser();

            if (user == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_message"] = "You are not logged in.";
                }

                filterContext.Result = new RedirectToActionResult("Signin", "Home", new { area = "" });
                return;
            }

            MyContext db = filterContext.HttpContext.RequestServices.GetService<MyContext>();

            if (user.Employee != null)
            {
                // admin can access
                if (_admin && user.Employee.Any(x => (bool)x.isAdmin))
                {
                    await next();
                    filterContext.Result = new RedirectToActionResult("Index", "Home", new { Area = "Admin" });
                    return;
                }
                // repairman can access
                if (_repairman && user.Employee.Any(x => (bool)x.isRepairman))
                {
                    await next();
                    filterContext.Result = new RedirectToActionResult("Index", "Home", new { Area = "Repairman" });
                    return;
                }
                // seller can access
                if (_seller && user.Employee.Any(x => (bool)x.isSeller))
                {
                    await next();
                    filterContext.Result = new RedirectToActionResult("Index", "Home", new { Area = "Seller" });
                    return;
                }
            }
            // client can access
            if (_client && user.isClient)
            {
                await next();
                filterContext.Result = new RedirectToActionResult("Index", "Home", new { Area = "Client" });
                return;
            }

            if(filterContext.Controller is Controller c1)
            {
                c1.ViewData["error_message"] = "You dont have access to this resource.";
            }
            filterContext.Result = new RedirectToActionResult("Signin", "Home", new { @area = "" });
        }

        public void OnActionExecuted(ActionResult context) { }
    }
}
