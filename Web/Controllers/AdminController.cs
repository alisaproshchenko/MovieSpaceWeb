using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Contexts;
using IdentityService.Models;
using IdentityService.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly ApplicationUserService _userService;
        private readonly ApplicationUserManager _manager;

        public AdminController()
        {
            _manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new IdentityContext()));
            _userService = new ApplicationUserService(_manager);
        }
        public ActionResult Index()
        {
            var userDtOs = _userService.GetAll();
            var users = Mapper.Map<IEnumerable<UserViewModel>>(userDtOs);
            
            return View(users);
        }
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}