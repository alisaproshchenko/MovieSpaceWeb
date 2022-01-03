﻿using System.Web.Mvc;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Services;
using Web.ViewModels;
using Web.ViewModels.Identity;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationUserService _userService;

        public AccountController()
        {
            _userService = new ApplicationUserService();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View("Error");

            var userViewModel = new UserViewModel
            {
                Banned = false, Email = model.Email, Name = model.Name, Password = model.Password,
                Surname = model.Surname, UserName = model.Username
            };
            var userDto = Mapper.Map<UserViewModel, ApplicationUserDto>(userViewModel);
            _userService.AddUser(userDto);

            return RedirectToAction("Index", "Admin");
        }
    }
}