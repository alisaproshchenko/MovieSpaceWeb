using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesService.Dto
{
    class MediaDto
    {
        public string IMDbMovieId { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        //maybe int
        public int Types { get; set; }
        public string Countries { get; set; }
        public string Cast { get; set; }
        public string Plot { get; set; }
        public int? BudgetAndBoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public double? SiteUsersRatings { get; set; }
        public List<GenresDto> GenresList { get; set; } = new List<GenresDto>();
        public List<SeasonsDto> SeasonsList { get; set; } = new List<SeasonsDto>();
    }
}