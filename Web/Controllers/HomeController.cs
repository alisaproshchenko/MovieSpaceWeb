using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Context;
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
        public ActionResult Search(string searchData)
        {
            //var model = context.MediaTable.Include("Types").Include("GenresCollection").Include("CountryCollection").Include("SeasonsList").FirstOrDefault(x => x.Name == searchData);
            //if (model == null)
            //{
                var searchApi = new SearchMovieInIMDbApi("k_zx5739ek");
                var model = searchApi.SearchMedia(searchData);
            //}
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

            //var model = _repository.SearchMedia(searchData);
            //if (model == null)
            //{
            //    var searchApi = new SearchMovieInIMDbApi();
            //    model = searchApi.SearchMedia(searchData);
            //    return View("SearchResult", new GenericEntitiesViewModel<Media>(model));
            //}
            //else
            //{
            //    return View("SearchResult", new GenericEntitiesViewModel<Media>(_repository.GetEntity(model.Id)));
            //}
        }
    }
}