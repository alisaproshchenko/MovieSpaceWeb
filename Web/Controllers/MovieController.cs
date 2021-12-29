using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Resources;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly IServices<MediaDto> _service;
        public MovieController(IServices<MediaDto> service) => this._service = service;

        public ActionResult ListOfEntities()
        {
            var media = Mapper.Map<IEnumerable<MediaDto>, IEnumerable<MediaViewModel>>(_service.Items);
            return View(media);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MediaDto entity)
        {
            entity.TypesId = Convert.ToInt32(MediaType.Movie);
            _service.AddItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(MediaDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(MediaDto entity)
        {
            _service.EditItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(MediaDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(MediaDto entity)
        {
            _service.DeleteItem(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}