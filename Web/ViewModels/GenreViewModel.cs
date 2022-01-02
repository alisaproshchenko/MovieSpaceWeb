using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Dto;
using Web.Services;

namespace Web.ViewModels
{
    public class GenreViewModel
    {
       public IEnumerable<GenresDto> Genres { get; set; }
       public PaginatedOutput PaginatedOutput { get; set; } = new PaginatedOutput();
       public PageOption PageOption { get; set; } = new PageOption();

       public GenreViewModel(IEnumerable<GenresDto> genres, int currentPage)
       {
           Genres = genres.OrderBy(g => g.Id)
               .Skip((currentPage - 1) * PageOption.PageSize)
               .Take(PageOption.PageSize);
           PaginatedOutput.PageSize = PageOption.PageSize;
           PaginatedOutput.CurrentPage = currentPage;
           PaginatedOutput.TotalEntities = genres.Count();
           PaginatedOutput.TotalPages = (int) Math.Ceiling((decimal) genres.Count() / PageOption.PageSize);
       }
    }
}