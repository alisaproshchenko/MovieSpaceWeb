using System.Web.Mvc;
using IdentityService.Dto;
using IdentityService.Services;

namespace Web.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService<AboutUsDto> _aboutUsService;

        public AboutUsController(IAboutUsService<AboutUsDto> aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = _aboutUsService.GetAll();
            return View(data);

        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutUs/Create
        [HttpPost]
        public ActionResult Create(AboutUsDto item)
        {
            try
            {
                _aboutUsService.Add(item);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(AboutUsDto item)
        {
            _aboutUsService.Change(item);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(AboutUsDto item)
        {
            _aboutUsService.Delete(item);
            return RedirectToAction("Index");
        }
    }
}
