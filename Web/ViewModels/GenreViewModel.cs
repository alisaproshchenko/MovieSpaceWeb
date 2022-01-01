using System.Collections.Generic;
using MoviesService.Dto;

namespace Web.ViewModels
{
    public class GenreViewModel
    {
       public IEnumerable<GenresDto> Genres { get; set; }
       public PaginatedOutput PaginatedOutput { get; set; }
    }
}