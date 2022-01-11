using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Services;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IService<ApplicationUserDto> _userService;

        public AdminController(IService<ApplicationUserDto> userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
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

        public ActionResult BanToggle(string id)
        {
            var userDTO = _userService.GetByUsername(id);
            _userService.UserBanToggle(userDTO);
            return RedirectToAction("Index");
        }
        public ActionResult AdminRightsToggle(string username)
        {
            var userDTO = _userService.GetByUsername(username);
            _userService.AdminRightsToggle(userDTO);
            return RedirectToAction("Index");
        }
    }
}