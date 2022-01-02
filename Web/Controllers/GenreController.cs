using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.Services;
using Web.ViewModels;

namespace Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IServices<GenresDto> _service;
        public GenreController(IServices<GenresDto> service) => this._service = service;

        public ActionResult ListOfEntities(int currentPage = 1)
        {
            return View(new GenreViewModel(_service.Items, currentPage));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GenresDto entity)
        {
            _service.AddItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(GenresDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(GenresDto entity)
        {
            _service.EditItem(entity);
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
            _service.DeleteItem(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}