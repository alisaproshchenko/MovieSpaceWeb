using System.Linq;
using System.Web.Mvc;
using IdentityService.Dto;
using IdentityService.Services;
using Microsoft.AspNet.Identity;
using MoviesService.Models;
using MoviesService.Repositories.Repository;

namespace Web.Controllers
{
    public class LikeWatchedController : Controller
    {
        private readonly LikeWatchedRepository _repository;
        private readonly IService<ApplicationUserDto> _userService;

        public LikeWatchedController(LikeWatchedRepository repository, IService<ApplicationUserDto> userService)
        {
            _repository = repository;
            _userService = userService;
        }
        [Authorize]
        public ActionResult Like(Media mediaDto)
        {
            var userAmount = _userService.GetAll().Count();
            mediaDto = _repository.Like(mediaDto.Id, userAmount, User.Identity.GetUserId());
            return RedirectToAction("Details", "Media", new {id = mediaDto.Id});
        }
    }
}