using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using IdentityService.Dto;
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
        public async Task<ActionResult> Register(RegistrationViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var errors = _userService.Validate(model.Password);
            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }
                return View(model);
            }

            var userViewModel = new UserViewModel
            {
                Banned = false,
                Email = model.Email,
                Name = model.Name,
                Password = model.Password,
                Surname = model.Surname,
                UserName = model.Username
            };
            var userDto = Mapper.Map<UserViewModel, ApplicationUserDto>(userViewModel);
            _userService.AddUser(userDto);

            var loginModel = new LoginModel { UserName = model.Username, Password = model.Password };

            return await Login(loginModel, null);
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
                var user = await _userService.UnitOfWork.UserManager.FindAsync(model.UserName, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
                else
                {
                    if (user.Banned)
                    {
                        ModelState.AddModelError("", "Unfortunately, this user is banned");
                        return View(model);
                    }

                    var claim = await _userService.UnitOfWork.UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.Now.AddMinutes(30)
                    }, claim);
                    if (string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}