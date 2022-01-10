using System.Web.Mvc;
using MoviesService.Repositories.Repository;
using MoviesService.Services.Service;

namespace Web.Controllers
{
    public class LikeWatchedController : Controller
    {
        private readonly LikeWatchedRepository _repository;
        private readonly MediaService _service;

        public LikeWatchedController(LikeWatchedRepository repository, MediaService service)
        {
            _repository = repository;
            _service = service;
        }

        // GET: LikeWatched
        public ActionResult Like(string userId, int movieId)
        {
            _repository.Like(movieId);
            return RedirectToAction("Details", "Media", new {id = movieId });
        }
    }
}