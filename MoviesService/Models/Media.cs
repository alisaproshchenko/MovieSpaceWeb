using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Media
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string IMDbMovieId { get; set; }
        [Required]
        public string Name { get; set; }
        //[Required]
        public string Poster { get; set; }
        [Required]
        public int Year { get; set; }
        public string Cast { get; set; }
        [Required]
        public string Plot { get; set; }
        public string Budget { get; set; }
        public string BoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public int? AmountOfLikes { get; set; } = 0;
        public double? SiteUsersRatings { get; set; } = 0;
        public string LinkEmbed { get; set; }
        public int SeasonCount { get; set; } = 0;
        [Required]
        public int TypesId { get; set; }
        public Types Types { get; set; }
        public virtual ICollection<Genres> GenresCollection { get; set; } = new List<Genres>();
        public ICollection<Seasons> SeasonsList { get; set; } = new List<Seasons>();
        public virtual ICollection<Country> CountryCollection { get; set; } = new List<Country>();
    }
}