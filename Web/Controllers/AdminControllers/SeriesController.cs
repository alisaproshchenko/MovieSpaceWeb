using System.Web.Mvc;
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
    }
}