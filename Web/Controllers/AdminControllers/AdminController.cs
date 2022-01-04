using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Services;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class AdminController : Controller
    {
        private readonly IService<ApplicationUserDto> _userService;

        public AdminController(IService<ApplicationUserDto> userService)
        {
            _userService = userService;
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
        public ActionResult AdminPanel()
        {
            return View();
        }
    }
}