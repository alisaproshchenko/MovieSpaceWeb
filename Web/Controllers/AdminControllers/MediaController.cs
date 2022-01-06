using System.Linq;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.IService;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class MediaController : Controller
    {
        private readonly MediaService _service;
        private readonly IServices<GenresDto> _genreServices;
        private readonly IServices<CountryDto> _countryServices;
        private readonly IServices<TypesDto> _typesServices;

        public MediaController(MediaService service, IServices<GenresDto> genreServices,
            IServices<CountryDto> countryServices, IServices<TypesDto> typesServices)
        {
            this._service = service;
            this._genreServices = genreServices;
            this._countryServices = countryServices;
            this._typesServices = typesServices;
        }

        public ActionResult Details(MediaDto mediaDto)
        {
            return View(new GenericEntitiesViewModel<MediaDto>(_service.Entities.FirstOrDefault(x => x.Id == mediaDto.Id)));
        }

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new MediaViewModel(_service.Entities, currentPage));
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            ViewBag.Genres = _genreServices.Entities;
            ViewBag.Country = _countryServices.Entities;
            ViewBag.Types = _typesServices.Entities;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Add(MediaDto entity, int selectedType, int [] selectedGenres, int[] selectedCountries)
        {
            _service.AddMedia(entity, selectedType, selectedGenres, selectedCountries);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(MediaDto entity)
        {
            return View(new GenericEntitiesViewModel<MediaDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Update(MediaDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(MediaDto entity)
        {
            return View(new GenericEntitiesViewModel<MediaDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(MediaDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}