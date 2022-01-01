using System;

namespace Web.ViewModels
{
    public class PaginatedOutput
    {
        public int TotalEntities { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

    }
}