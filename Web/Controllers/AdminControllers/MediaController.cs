﻿using System.Linq;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Repositories.Repository;
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
        private readonly MediaRepository _mediaRepository;

        public MediaController(MediaService service, IServices<GenresDto> genreServices,
            IServices<CountryDto> countryServices, IServices<TypesDto> typesServices, MediaRepository mediaRepository)
        {
            this._service = service;
            this._genreServices = genreServices;
            this._countryServices = countryServices;
            this._typesServices = typesServices;
            this._mediaRepository = mediaRepository;
        }

        public ActionResult Details(MediaDto mediaDto)
        {
            return View(_mediaRepository.Entities.FirstOrDefault(x => x.Id == mediaDto.Id));
        }

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new MediaViewModel(_service.Entities, currentPage));
        }

        public ActionResult Add()
        {
            ViewBag.Genres = _genreServices.Entities;
            ViewBag.Country = _countryServices.Entities;
            ViewBag.Types = _typesServices.Entities;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MediaDto entity, int selectedType, int [] selectedGenres, int[] selectedCountries)
        {
            _service.AddMedia(entity, selectedType, selectedGenres, selectedCountries);
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