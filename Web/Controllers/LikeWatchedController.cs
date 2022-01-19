using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoviesService.Models;
using MoviesService.Repositories.Repository;

namespace Web.Controllers
{
    public class LikeWatchedController : Controller
    {
        private readonly LikeWatchedRepository _repository;
        private readonly LikeWatchedRepository _userToMedia;

        public LikeWatchedController(LikeWatchedRepository repository, LikeWatchedRepository userToMedia)
        {
            _repository = repository;
            _userToMedia = userToMedia;
        }
        [Authorize]
        public ActionResult Like(Media mediaDto)
        {
            var userAmount = _userToMedia.Entities.Count(movie => movie.MediaId == mediaDto.Id);
            mediaDto = _repository.Like(mediaDto.Id, userAmount, User.Identity.GetUserId());
            return RedirectToAction("Details", "Media", new {id = mediaDto.Id});
        }

        [Authorize]
        public ActionResult AddToMyList(string userId, int mediaId)
        {
            _repository.AddMyList(userId, mediaId);
            return RedirectToAction("Details", "Media", new { id = mediaId });
        }

        [Authorize]
        public ActionResult DeleteFromMyList(string userId, int mediaId)
        {
            _repository.DeleteFromMyList(userId, mediaId);
            return RedirectToAction("Index", "Home");
        }
    }
}