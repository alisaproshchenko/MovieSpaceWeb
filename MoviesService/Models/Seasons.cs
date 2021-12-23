using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesService.Models
{
    public class Seasons
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string SeriesId { get; set; }
        [Required]
        public string IMDbMovieId { get; set; }
        [Required]
        public int Year { get; set; }
        public double? RatingIMDb { get; set; }
        public double? UserIMDb { get; set; }
    }
}