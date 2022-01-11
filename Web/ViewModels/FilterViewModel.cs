using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MoviesService.Models;
using Web.Services;

namespace Web.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<Media> Media { get; set; }
        public SelectList Genre { get; set; }
        public SelectList Year { get; set; }
        public SelectList Type { get; set; }
        public PaginatedOutput PaginatedOutput { get; set; } = new PaginatedOutput();
        public PageOption PageOption { get; set; } = new PageOption();
        public FilterViewModel(IEnumerable<Media> entities,List<string> year, LinkedList<Genres> genre, List<string> type, int currentPage)
        {
            Year = new SelectList(year);
            Type = new SelectList(type);
            Genre = new SelectList(genre, "Id", "Name");
            Media = entities.OrderBy(g => g.Id)
                .Skip((currentPage - 1) * PageOption.PageSize)
                .Take(PageOption.PageSize);
            PaginatedOutput.PageSize = PageOption.PageSize;
            PaginatedOutput.CurrentPage = currentPage;
            PaginatedOutput.TotalEntities = entities.Count();
            PaginatedOutput.TotalPages = (int)Math.Ceiling((decimal)entities.Count() / PageOption.PageSize);
        }
    }
}