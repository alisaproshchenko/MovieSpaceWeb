using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IServices<GenresDto> service;
        public MovieController(IServices<GenresDto> service) => this.service = service;

        public ActionResult Index()
        {
            var d = Mapper.Map<IEnumerable<GenresDto>, IEnumerable<GenreViewModel>>(service.Items);
            return View(d);
        }
        // GET: Movie
        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(GenresDto food)
        {
            service.AddItem(food);
            return RedirectToAction("Index");
        }

        public ActionResult EditFood(GenresDto food)
        {
            return View(food);
        }
        [HttpPost]
        public ActionResult UpdateFood(GenresDto food)
        {
            service.EditItem(food);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(GenresDto food)
        {
            return View(food);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(GenresDto food)
        {
            service.DeleteItem(food);
            return RedirectToAction("Index");
        }
    }
}