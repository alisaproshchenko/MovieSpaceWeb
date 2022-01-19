using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    [Authorize(Roles = "Administrator")]
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
        public ActionResult Edit(int id)
        {
            return View(new GenericEntitiesViewModel<TypesDto>(_service.GetEntity(id)));
        }
        [HttpPost]
        public ActionResult Update(int id)
        {
            _service.Edit(_service.GetEntity(id));
            return RedirectToAction("ListOfEntities");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new GenericEntitiesViewModel<TypesDto>(_service.GetEntity(id)));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Delete(_service.GetEntity(id));
            return RedirectToAction("ListOfEntities");
        }
    }
}