using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MoviesService.IMDbApi;

namespace Web.Controllers
{
    public class SearchMovieController : Controller
    {
        // GET: SearchMovie
        public ActionResult Search()
        {
            return View("SearchMainPage");
        }

        [HttpPost]
        public async Task<ActionResult> Search(string searchData)
        {
            var searchMovie = new SearchMovieInIMDbApi();

            var model = await searchMovie.SearchAsynTask(searchData);

            return View("SearchResult", model);
        }
    }
}