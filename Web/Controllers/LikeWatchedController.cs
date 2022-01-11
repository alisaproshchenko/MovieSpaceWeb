using System.Web.Mvc;
using MoviesService.Models;
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
        public ActionResult Like(Media mediaDto)
        {
            mediaDto = _repository.Like(mediaDto.Id);
            return RedirectToAction("Details", "Media", mediaDto);
        }
    }
}