using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Models;
using MoviesService.Services.IService;
using MoviesService.Services.Service;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MovieController : Controller
    {
        private readonly MediaService _service;
        private readonly IServices<TypesDto> _typeServices;
        private readonly IServices<GenresDto> _genreServices;
        public MovieController(MediaService service, IServices<TypesDto> typeServices, IServices<GenresDto> genreServices)
        {
            this._service = service;
            this._typeServices = typeServices;
            this._genreServices = genreServices;
        }

        public ActionResult ListOfEntities()
        {
            var media = Mapper.Map<IEnumerable<MediaDto>, IEnumerable<MediaViewModel>>(_service.Items);
            return View(media);
        }

        public ActionResult Add()
        {
            ViewBag.Genres = _genreServices.Items;
            return View();
        }

        [HttpPost]
        public ActionResult Add(MediaDto entity, int [] entities)
        {
            var typeDto = _typeServices.Items.FirstOrDefault(x => x.Id == 1);
            entity.Types = new Types(); 
            entity.GenresCollection = new List<Genres>();
            entity.Types = Mapper.Map<TypesDto, Types>(typeDto);
            foreach (var c in _genreServices.Items.Where(co => entities.Contains(co.Id)))
            {
                entity.GenresCollection.Add(Mapper.Map<GenresDto,Genres>(c));
            }

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