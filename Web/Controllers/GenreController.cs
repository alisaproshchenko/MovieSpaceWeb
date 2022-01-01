using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using MoviesService.Dto;
using MoviesService.Services.IService;
using Web.ViewModels;

namespace Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IServices<GenresDto> _service;
        public int PageSize = 3;
        public GenreController(IServices<GenresDto> service) => this._service = service;

        public ActionResult ListOfEntities(int productPage = 1)
        {
            var genres = Mapper.Map<IEnumerable<GenresDto>, IEnumerable<GenreViewModel>>(_service.Items);
            return View(new GenreViewModel
            {
                Genres = _service.Items
                    .OrderBy(g => g.Id)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PaginatedOutput = new PaginatedOutput
                {
                    CurrentPage = productPage,
                    PageSize = PageSize,
                    TotalEntities = _service.Items.Count(),
                    TotalPages = (int)Math.Ceiling((decimal)_service.Items.Count() / PageSize)
                }
            });
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(GenresDto entity)
        {
            _service.AddItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        public ActionResult Edit(GenresDto entity)
        {
            return View(entity);
        }
        [HttpPost]
        public ActionResult Update(GenresDto entity)
        {
            _service.EditItem(entity);
            return RedirectToAction("ListOfEntities");
        }

        [HttpGet]
        public ActionResult Delete(GenresDto entity)
        {
            return View(entity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(GenresDto entity)
        {
            _service.DeleteItem(entity);
            return RedirectToAction("ListOfEntities");
        }
    }
}