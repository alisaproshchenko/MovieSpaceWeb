using System.Linq;
using MoviesService.IMDbApi;
using Web.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MoviesService.Repositories.Repository;
using MoviesService.Search;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConvertorApiData _convertor = new ConvertorApiData();        
        private readonly LikeWatchedRepository _repository;
        private readonly MediaRepository _repositoryMedia;

        public HomeController(LikeWatchedRepository repository, MediaRepository repositoryMedia)
        {
            _repository = repository;
            _repositoryMedia = repositoryMedia;
        }
        private static readonly SearchInDataBase _search = new SearchInDataBase();

        [HttpGet]
        public ActionResult Index()
        {
            var search = new SearchInDataBase();
            var model = search.MediaList();
            var usersTo = search.UsersToMedia();
            return View(new HomePageViewModel(usersTo, model,User.Identity.GetUserId()));
        }

        [HttpGet]
        public ActionResult MostLikedResult(int currentPage = 1)
        {
            var model = _search.MostLikeMovies();
            return View("MostLiked", new MediaViewModel(model, currentPage));
        }

        [HttpGet]
        public ActionResult Top250IMDb(int currentPage = 1)
        {
            var model = _search.MediaTop250List();
            return View("Top250ByIMDb", new MediaViewModel(model, currentPage));
        }

        [HttpGet]
        public ActionResult MostWatchedResult(int currentPage = 1)
        {
            var model = _search.MostWatched();
            return View("MostWatched", new MediaViewModel(model, currentPage));
        }

        [HttpGet]
        public ActionResult Filters(string genre, string country, string year, string type, int currentPage = 1)
        {
            var model = _search.MediaList();

            if (country != null && _convertor.StrToInt(country) != 0)
                model = _search.SearchByCountry(country, model);

            if (genre != null && _convertor.StrToInt(genre) != 0)
                model = _search.SearchByGenre(genre, model);

            if ((year != null || _convertor.StrToInt(year) != 0) && year != "All")
                model = _search.SearchByYear(year, model);

            if ((type != null || _convertor.StrToInt(type) != 0) && type != "All")
                model = _search.SearchByType(type, model);

            var genreModel = _search.GenreList();
            var years = _search.YearList();
            var types = _search.TypesList();
            var countries = _search.CountryList();

            var model2 = new FilterViewModel(model, years,genreModel,countries, types, currentPage);

            return View("Filters", model2);
        }

        [HttpPost]
        public ActionResult Search(string searchData)
        {
            var model = _search.SearchByName(searchData);

            if (model == null || model.Count == 0)
            {
                var searchApi = new SearchMovieInIMDbApi("k_wxbph9cx");
                model = searchApi.SearchMedia(searchData);
                return View("SearchResultApi", model);
            }

            return View("SearchResult", model);
        }
    }
}