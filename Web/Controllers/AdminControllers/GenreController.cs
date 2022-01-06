using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers.AdminControllers
{
    public class GenreController : Controller
    {
        private readonly GenreService _service;
        public GenreController(GenreService service) => this._service = service;

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new GenreViewModel(_service.Entities, currentPage));
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Add(GenresDto entity)
        {
            _service.Add(entity);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(GenresDto entity)
        {
            return View(new GenericEntitiesViewModel<GenresDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Update(GenresDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Delete(GenresDto entity)
        {
            return View(new GenericEntitiesViewModel<GenresDto>(entity));
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(GenresDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}