﻿using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Contexts;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Web.ViewModels;
using Web.ViewModels.Identity;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationUserManager _manager;
        private readonly ApplicationUserService _userService;

        public AccountController()
        {
            _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new IdentityContext()));
            _userService = new ApplicationUserService(_manager);
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View("Error");

            var userViewModel = Mapper.Map<RegistrationViewModel, UserViewModel>(model);
            var userDto = Mapper.Map<UserViewModel, ApplicationUserDto>(userViewModel);
            _userService.AddUser(userDto);

            return RedirectToAction("Index", "Admin");
        }
    }
}