using System.Linq;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class SeriesController : Controller
    {
        private readonly SeasonService _service;
        private readonly EpisodeService _episodeService;
        public SeriesController(SeasonService service, EpisodeService episodeService)
        {
            _service = service;
            _episodeService = episodeService;
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult AddSeason(int mediaId)
        {
            _service.AddSeason(mediaId);
            return RedirectToAction("Details", "Media", new {id = mediaId});
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult AddEpisode(int id)
        {
            _episodeService.AddEpisode(id);
            return RedirectToAction("GetSeason", new { seasonId = id });
        }
        public ActionResult GetSeason(int seasonId)
        {
            return View(new GenericEntitiesViewModel<SeasonsDto>(_service.Entities.FirstOrDefault(x => x.Id == seasonId)));
        }

        public ActionResult GetEpisode(int episodeId)
        {
            return View(new GenericEntitiesViewModel<EpisodeDto>(_episodeService.Entities.FirstOrDefault(x => x.Id == episodeId)));
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult DeleteSeason(SeasonsDto entity)
        {
            return View(new GenericEntitiesViewModel<SeasonsDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("DeleteSeason")]
        public ActionResult DeleteConfirmedSeason(int seasonId)
        {
            var season = _service.Entities.FirstOrDefault(x => x.Id == seasonId);
            _service.Delete(season);
            return RedirectToAction("Details", "Media", new {id = season.MediaId});
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult DeleteEpisode(EpisodeDto entity)
        {
            return View(new GenericEntitiesViewModel<EpisodeDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("DeleteEpisode")]
        public ActionResult DeleteConfirmedEpisode(int episodeId)
        {
            var episode = _episodeService.Entities.FirstOrDefault(x => x.Id == episodeId);
            _episodeService.Delete(episode);
            return RedirectToAction("GetSeason", "Series", new { seasonId = episode.SeasonsId });
        }
    }
}