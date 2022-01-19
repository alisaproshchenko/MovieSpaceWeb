using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoviesService.Dto;
using MoviesService.IMDbApi;
using MoviesService.Repositories.Repository;
using MoviesService.Search;
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
        private readonly LikeWatchedRepository _likeWatchedRepository;

        public MediaController(MediaService service, IServices<GenresDto> genreServices,
            IServices<CountryDto> countryServices, IServices<TypesDto> typesServices, LikeWatchedRepository likeWatchedRepository)
        {
            this._service = service;
            this._genreServices = genreServices;
            this._countryServices = countryServices;
            this._typesServices = typesServices;
            this._likeWatchedRepository = likeWatchedRepository;
        }

        public ActionResult Details(int id)
        {
            var search = new SearchInDataBase();
            var model = search.MediaList().FirstOrDefault(x => x.Id == id);
            if (User.Identity.IsAuthenticated)
            {
                _likeWatchedRepository.Watch(User.Identity.GetUserId(), id);
            }
            return View("Details", model);
        }

        public ActionResult DetailsApi(string id)
        {
            var search = new SearchMovieInIMDbApi();
            var model = search.SearchTitle(id);

            return View("DetailsApi", model);
        }

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            var search = new SearchInDataBase();
            var model = search.MediaList();
            return View(new MediaViewModel(model, currentPage));
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
            var search = new SearchInDataBase();
            if (search.CheckByName(entity.Name))
                return View("ErrorAdd");
            _service.AddMedia(entity, selectedType, selectedGenres, selectedCountries);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            ViewBag.Genres = _genreServices.Entities;
            ViewBag.Countries = _countryServices.Entities;
            ViewBag.Types = _typesServices.Entities;
            return View(new GenericEntitiesViewModel<MediaDto>(_service.GetEntity(id)));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Update(MediaDto entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            _service.EditMedia(entity, selectedType,selectedGenresIds,selectedCountriesIds);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new GenericEntitiesViewModel<MediaDto>(_service.GetEntity(id)));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(_service.GetEntity(id));
            return RedirectToAction("ListOfEntities");
        }
    }
}