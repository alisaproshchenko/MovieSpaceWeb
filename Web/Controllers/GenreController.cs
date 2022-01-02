using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IServices<GenresDto> _service;
        public GenreController(IServices<GenresDto> service) => this._service = service;

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new GenreViewModel(_service.Entities, currentPage));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GenresDto entity)
        {
            _service.Add(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(GenresDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(GenresDto entity)
        {
            _service.Edit(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(GenresDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(GenresDto entity)
        {
            _service.Delete(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}