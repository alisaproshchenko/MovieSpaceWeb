﻿using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class CountryController : Controller
    {
        private readonly IServices<CountryDto> _service;
        public CountryController(IServices<CountryDto> service) => this._service = service;

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new CountryViewModel(_service.Entities, currentPage));
        }
        // GET: Movie
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CountryDto entity)
        {
            _service.Add(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(CountryDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(CountryDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(CountryDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(CountryDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}