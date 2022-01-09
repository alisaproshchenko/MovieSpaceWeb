using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Context;
using MoviesService.IMDbApi;
using MoviesService.Models;
using Web.ViewModels;
using System.Web.Mvc;
using MoviesService.Repositories.Repository;
using MoviesService.Search;


namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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