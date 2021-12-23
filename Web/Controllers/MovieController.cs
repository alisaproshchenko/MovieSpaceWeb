using System.Linq;
using System.Web.Mvc;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        protected readonly IMediaRepository<Genres> repository;
        public MovieController(IMediaRepository<Genres> repository) => this.repository = repository;
        public ActionResult Index()
        {
            return View(repository.Items);
        }
        // GET: Movie
        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(Genres food)
        {
            repository.AddItem(food);
            return RedirectToAction("Index");

        }

        public ActionResult EditFood(int id)
        {
            var genre = repository.Items.FirstOrDefault(i => i.Id == id);
            return View(genre);
        }
        [HttpPost]
        public ActionResult UpdateFood(Genres food)
        {
            repository.EditItem(food);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var b = repository.Items.FirstOrDefault(i => i.Id == id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var b = repository.Items.FirstOrDefault(i => i.Id == id);
            if (b == null)
            {
                return HttpNotFound();
            }
            repository.DeleteItem(b.Id);
            return RedirectToAction("Index");
        }
    }
}