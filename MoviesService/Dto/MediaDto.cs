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
        public string Budget { get; set; }
        public string BoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public double? SiteUsersRatings { get; set; }
        public string LinkEmbed { get; set; }
        public int TypesId { get; set; }
        public Types Types { get; set; } 
        public int SeasonCount { get; set; }
        public ICollection<Genres> GenresCollection { get; set; } = new List<Genres>();
        public ICollection<Country> CountryCollection { get; set; } = new List<Country>();
        public ICollection<Seasons> SeasonsList { get; set; } = new List<Seasons>();

    }
}