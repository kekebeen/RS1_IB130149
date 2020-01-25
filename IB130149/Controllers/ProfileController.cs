using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IB130149.Context;
using IB130149.Models;
using IB130149.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IB130149.Controllers
{
    public class ProfileController : Controller
    {
        private MyContext _context;

        public ProfileController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("/Home/Profile/{id:int?}")]
        public IActionResult Index(int id)
        {
            // ID is passed from context of the logged user (no need to check that.);
            // Find user with associated profileId and map with model;
            if(id == null)
            {
                TempData["error_message"] = "There is a problem loading profileId. Please try again";
                return RedirectToAction("Index", "Home", new { area = "" }, null);
            }

            User user = _context.User.Where(x => x.Id == id).SingleOrDefault();

            if(user == null)
            {
                TempData["error_message"] = "There is no associated user with this id";
                return RedirectToAction("Index", "Home", new { area = "" }, null);
            }

            // if there is user, map viewmodel;
            ProfileUpdateVm vm = new ProfileUpdateVm
            {
                Username = user.Username,
                UserId = user.Id,
                OldPassword = user.Password,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Telephone = user.Telephone,
                Address = user.Address,
            };
            // pass ID of the current profile request and pass it down to the form view
            // make it invisible on the form and do logic elsewhere i.e another action
            return View(vm);
        }

        public IActionResult Update(ProfileUpdateVm model)
        {
            // check if old and new passwords are the same
            if (model.OldPassword == model.NewPassword)
            {
                TempData["error_message"] = "Old password and password cannot be the same value.";
                return RedirectToAction("Index", model.UserId);
            }

            // find user and update its value
            User user = _context.User.SingleOrDefault(x => x.Id == model.UserId);

            if(user != null)
            {
                // check if password is ok
                if(user.Password != model.OldPassword)
                {
                    TempData["error_message"] = "Your old password is incorrect.";
                    return View("Index", model);
                }

                user.Name = model.Name;
                user.Password = model.NewPassword;
                user.Surname = model.Surname;
                user.Telephone = model.Telephone;
                user.Username = model.Username;
                user.Email = model.Email;
                user.Address = model.Address;

                _context.SaveChanges();

                TempData["success_message"] = "User updated successfully.";
            }
            // go to home page
            return RedirectToAction("Index", model.UserId);
        }
    }
}