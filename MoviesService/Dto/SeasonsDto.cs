using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService.Dto
{
    class SeasonsDto
    {
        public string SeriesId { get; set; }
        public string IMDbMovieId { get; set; }
        public int Year { get; set; }
        public double? RatingIMDb { get; set; }
        public double? UserIMDb { get; set; }
    }
}