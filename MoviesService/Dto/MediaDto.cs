using MoviesService.Models;
using System.Collections.Generic;

namespace MoviesService.Dto
{
    public class MediaDto
    {
        public int Id { get; set; }
        public string IMDbMovieId { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public string Cast { get; set; }
        public string Plot { get; set; }
        public int? BudgetAndBoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public double? SiteUsersRatings { get; set; }
        public List<Genres> GenresList { get; set; } = new List<Genres>();
        public List<Seasons> SeasonsList { get; set; } = new List<Seasons>();
        public List<Country> CountriesList { get; set; } = new List<Country>();
    }
}