using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesService.Models
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IMDbMovieId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Poster { get; set; }
        [Required]
        public int Year { get; set; }
        public string Cast { get; set; }
        [Required]
        public string Plot { get; set; }
        public int? BudgetAndBoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public double? SiteUsersRatings { get; set; }
        public Types Types { get; set; }
        [Required]
        public List<Genres> GenresList { get; set; } = new List<Genres>();
        public List<Seasons> SeasonsList { get; set; } = new List<Seasons>();
        public List<Country> CountriesList { get; set; } = new List<Country>();
    }
}