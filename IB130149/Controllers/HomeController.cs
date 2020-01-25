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
using IB130149.ViewModels;

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

        public IActionResult Index()
        {
            // On initial route catch, check logged in user role and redirect accordingly to the areas.
            User user = HttpContext.GetLoggedInuser();
            
            if(user == null)
            {
                TempData["error_message"] = "You don't have access rights. Please login below.";
                return RedirectToAction("Signin", "Home");
            }
            // Check user roles and assign him to the area
            // Client role
            if(user.isClient)
            {
                return RedirectToAction("Index", "Home", new { Area = "Client" });
            }

            if(user.Employee != null)
            {
                if(user.Employee.Any(x => (bool)x.isAdmin))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }

                if (user.Employee.Any(x => (bool)x.isRepairman))
                {
                    return RedirectToAction("Index", "Home", new { Area = "Repairman" });
                }

                if (user.Employee.Any(x => (bool)x.isSeller))
                {
                    return RedirectToAction("Index", "Request", new { Area = "Seller" });
                }

            }
            return RedirectToAction("Signin", "Home");
        }

        public IActionResult Signin(LoginVM? model)
        {
            return View(model);
        }

        public IActionResult Login(LoginVM model)
        {
            User user = _context.User.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                TempData["error_message"] = "Wrong username or password.";
                return View("Signin", model);
            }

            HttpContext.SetLoggedUser(user, model.RememberMe);
            // Home index action will take care of the role redirection for the current user role.
            return RedirectToAction("Index");
        }

        public IActionResult Signup(SignupVm? model)
        {
            TempData["error_message"] = (String)TempData["error_message"];
            return View(model);
        }

        public IActionResult Register(SignupVm model)
        {
            // check if model state is ok
            if(!ModelState.IsValid)
            {
                TempData["error_message"] = "Oops. Please check your data.";
                return View("Signup");
            }
            // check if username/email already exists in db
            User user = _context.User.Where(x => x.Email == model.Email).SingleOrDefault();
            
            if(user != null)
            {
                TempData["error_message"] = "User with given email address already exists. Please try something else.";
                return View("Signup",model);
            }

            // create new user object
             User newUser = new User
            {
                Username = model.Username,
                Password = model.Password,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Address = model.Address,
                Telephone = model.Telephone,
                isClient = true
            };

            LoginVM loginViewModel = new LoginVM
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = false
            };

            // save to db
            _context.User.Add(newUser);
            _context.SaveChanges();
            // Use TempData and store temporarily loginVM model from the user object
            // Pass it down to the login view and prepolate the form.
            TempData["success_message"] = "You have successfully created new user. Please login below.";
            return View("Signin", loginViewModel);

        }

        public IActionResult Logout()
        {
            // Authorization helper handles cookie expiration date;
            // In case there is no RememberMe flag just delete from AuthorizationToken db;
            HttpContext.Logout();
            TempData["success_message"] = "You have successfully been logged out.";
            return RedirectToAction("Signin", "Home");
            // In case there is expiration, it should expire on its own(no helper needed here);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
