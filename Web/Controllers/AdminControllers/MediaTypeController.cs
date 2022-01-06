using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class MediaTypeController : Controller
    {
        private readonly TypeService _service;
        public MediaTypeController(TypeService service) => this._service = service;

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new TypeViewModel(_service.Entities, currentPage));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TypesDto entity)
        {
            _service.Add(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(TypesDto entity)
        {
            return View(new GenericEntitiesViewModel<TypesDto>(entity));
        }
        [HttpPost]
        public ActionResult Update(TypesDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(TypesDto entity)
        {
            return View(new GenericEntitiesViewModel<TypesDto>(entity));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(TypesDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}