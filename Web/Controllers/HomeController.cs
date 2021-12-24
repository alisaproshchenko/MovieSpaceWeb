using System.Data.Entity.Migrations;
using System.Web.Mvc;
using IdentityService.Contexts;
using IdentityService.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var context = new IdentityContext();
            //context.Users.AddOrUpdate(new ApplicationUser
            //{
            //    Name = "name",
            //    Surname = "surname",
            //    Banned = false,
            //    UserName = "username1"
            //});
            //context.SaveChanges();
            return View();
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