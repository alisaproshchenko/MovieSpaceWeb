using System;
using System.Collections.Generic;
using System.Linq;
using MoviesService.Dto;
using Web.Services;

namespace Web.ViewModels
{
    public class CountryViewModel
    {
        public IEnumerable<CountryDto> Countries { get; set; }
        public PaginatedOutput PaginatedOutput { get; set; } = new PaginatedOutput();
        public PageOption PageOption { get; set; } = new PageOption();

        public CountryViewModel(IEnumerable<CountryDto> entities, int currentPage)
        {
            Countries = entities.OrderBy(g => g.Id)
                .Skip((currentPage - 1) * PageOption.PageSize)
                .Take(PageOption.PageSize);
            PaginatedOutput.PageSize = PageOption.PageSize;
            PaginatedOutput.CurrentPage = currentPage;
            PaginatedOutput.TotalEntities = entities.Count();
            PaginatedOutput.TotalPages = (int)Math.Ceiling((decimal)entities.Count() / PageOption.PageSize);
        }
    }
}