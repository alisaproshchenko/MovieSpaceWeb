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

        public ActionResult Update(AboutUsDto item)
        {
            return View(item);
        }

        [HttpPost]
        public ActionResult Change(AboutUsDto item)
        {
            _aboutUsService.Change(item);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _aboutUsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
