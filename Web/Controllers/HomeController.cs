using System.Linq;
using MoviesService.IMDbApi;
using Web.ViewModels;
using System.Web.Mvc;
using MoviesService.Search;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConvertorApiData _convertor = new ConvertorApiData();
        private static readonly SearchInDataBase _search = new SearchInDataBase();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Top250IMDb(int currentPage = 1)
        {
            var model = _search.MediaList().Take(250).ToList();
            return View("Top250ByIMDb", new MediaViewModel(model, currentPage));
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

            if (model == null)
            {
                var searchApi = new SearchMovieInIMDbApi("k_ag12ki7h");
                model = searchApi.SearchMedia(searchData);
            }

            return View("SearchResult", model);
        }
    }
}