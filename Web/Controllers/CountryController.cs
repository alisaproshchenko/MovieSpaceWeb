using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly IServices<CountryDto> _service;
        public CountryController(IServices<CountryDto> service) => this._service = service;

        public ActionResult ListOfEntities()
        {
            var country = Mapper.Map<IEnumerable<CountryDto>, IEnumerable<CountryViewModel>>(_service.Items);
            return View(country);
        }
        // GET: Movie
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CountryDto entity)
        {
            _service.AddItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(CountryDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(CountryDto entity)
        {
            _service.EditItem(entity);
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
            _service.DeleteItem(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}