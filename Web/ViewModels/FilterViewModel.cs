using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesService.Dto;
using MoviesService.Models;

namespace Web.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<Media> Media { get; set; }
        public SelectList Genre { get; set; }
        public SelectList Year { get; set; }
    }
}