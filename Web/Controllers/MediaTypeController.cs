using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MediaTypeController : Controller
    {
        private readonly IServices<TypesDto> _service;
        public MediaTypeController(IServices<TypesDto> service) => this._service = service;

        public ActionResult ListOfEntities()
        {
            var types = Mapper.Map<IEnumerable<TypesDto>, IEnumerable<TypeViewModel>>(_service.Items);
            return View(types);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TypesDto entity)
        {
            _service.AddItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(TypesDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(TypesDto entity)
        {
            _service.EditItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(TypesDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(TypesDto entity)
        {
            _service.DeleteItem(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}