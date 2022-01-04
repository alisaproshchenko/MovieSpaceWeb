﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Web.ViewModels;
using Web.ViewModels.Identity;

namespace Web.Controllers.IdentityControllers
{
    public class AccountController : Controller
    {
        private readonly IService<ApplicationUserDto> _userService;
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public AccountController(IService<ApplicationUserDto> userService)
        {
            _userService = userService;
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

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userService.UnitOfWork.UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await _userService.UnitOfWork.UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}