using MoviesService.IMDbApi;
using MoviesService.Models;
using Web.ViewModels;
using System.Web.Mvc;
using MoviesService.Repositories.Repository;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MediaRepository _repository;
        public HomeController(MediaRepository repository) => _repository = repository;
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string searchData)
        {
            var model = _repository.SearchMedia(searchData);
            if (model == null)
            {
                var searchApi = new SearchMovieInIMDbApi();
                model = searchApi.SearchMedia(searchData);
                return View("SearchResult", new GenericEntitiesViewModel<Media>(model));
            }
            else
            {
                return View("SearchResult", new GenericEntitiesViewModel<Media>(_repository.GetEntity(model.Id)));
            }
        }
    }
}