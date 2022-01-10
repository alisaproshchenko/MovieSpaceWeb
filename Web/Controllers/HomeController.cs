using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Context;
using MoviesService.IMDbApi;
using MoviesService.Models;
using Web.ViewModels;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Repositories.Repository;
using MoviesService.Search;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConvertorApiData _convertor = new ConvertorApiData();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Filters(string genre, string year, string type, int currentPage = 1)
        {
            var search = new SearchInDataBase();
            var model = search.MediaList();

            if (genre != null && _convertor.StrToInt(genre) != 0)
                model = search.SearchByGenre(genre, model);

            if ((year != null || _convertor.StrToInt(year) != 0) && year != "All")
                model = search.SearchByYear(year, model);

            if ((type != null || _convertor.StrToInt(type) != 0) && type != "All")
                model = search.SearchByType(type, model);

            var genreModel = search.GenreList();
            var years = search.YearList();
            var types = search.TypesList();

            var model2 = new FilterViewModel(model, years,genreModel,types,currentPage);

            return View("Filters", model2);
        }

        [HttpPost]
        public ActionResult Search(string searchData)
        {
            var model = new SearchInDataBase().SearchByName(searchData);

            if (model == null)
            {
                var searchApi = new SearchMovieInIMDbApi("k_ag12ki7h");
                model = searchApi.SearchMedia(searchData);
            }

            return View("SearchResult", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}