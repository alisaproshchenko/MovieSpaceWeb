using System.Linq;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.Service;

namespace Web.Controllers.AdminControllers
{
    public class SeriesController : Controller
    {
        private readonly SeasonService _service;
        public SeriesController(SeasonService service) => _service = service;
        public ActionResult Add(int mediaId)
        {
            _service.Add(mediaId);
            return RedirectToAction("Details", "Media", new {id = mediaId});
        }
        public ActionResult GetSeason(int seasonId)
        {
            return View(_service.Entities.FirstOrDefault(x => x.Id == seasonId));
        }

        public ActionResult AddEpisode(int id)
        {
            _service.AddEpisode(id);
            return RedirectToAction("GetSeason", new {seasonId = id});
        }

        [HttpGet]
        public ActionResult DeleteSeason(SeasonsDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("DeleteSeason")]
        public ActionResult DeleteConfirmedSeason(int seasonId)
        {
            var season = _service.Entities.FirstOrDefault(x => x.Id == seasonId);
            _service.Delete(season);
            return RedirectToAction("Details", "Media", new {id = season.MediaId});
        }
    }
}