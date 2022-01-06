using System.Threading.Tasks;
using System.Web.Mvc;
using MoviesService.IMDbApi;

namespace Web.Controllers
{
    public class SearchMovieController : Controller
    {
        // GET: SearchMovie
        public ActionResult SearchMainPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SearchMainPage(string searchData)
        {
            var searchMovie = new SearchMovieInIMDbApi();

            var model = await searchMovie.SearchAsynTask(searchData);

            return View("SearchResult", model);
        }
    }
}