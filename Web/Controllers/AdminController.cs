using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationUserService _userService;

        public AdminController()
        {
            _userService = new ApplicationUserService();
        }
        public ActionResult Index()
        {
            //var userDTO = _userService.GetByUsername("your username");
            //_userService.AdminRightsToggle(userDTO);

            var userDtOs = _userService.GetAll();
            var users = Mapper.Map<IEnumerable<UserViewModel>>(userDtOs);
            foreach (var user in users)
            {
                user.Roles = _userService.GetRoles(user.UserName);
            }

            return View(users);
        }

    }
}