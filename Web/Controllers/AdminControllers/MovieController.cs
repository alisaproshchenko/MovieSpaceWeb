using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.IService;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class MovieController : Controller
    {
        private readonly MediaService _service;
        private readonly IServices<GenresDto> _genreServices;
        private readonly IServices<CountryDto> _countryServices;
        public MovieController(MediaService service, IServices<GenresDto> genreServices, IServices<CountryDto> countryServices)
        {
            this._service = service;
            this._genreServices = genreServices;
            this._countryServices = countryServices;
        }

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new MovieViewModel(_service.Entities, currentPage));
        }

        public ActionResult Add()
        {
            ViewBag.Genres = _genreServices.Entities;
            ViewBag.Country = _countryServices.Entities;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MediaDto entity, int [] selectedGenres, int[] selectedCountries)
        {
            _service.AddMedia(entity, 1, selectedGenres, selectedCountries);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(MediaDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(MediaDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(MediaDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(MediaDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}