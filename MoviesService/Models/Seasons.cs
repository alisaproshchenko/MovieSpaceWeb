using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Seasons
    {
        [Key]
        public int Id { set; get; }
        public string Name { get; set; }
        public int? MediaId { get; set; }
        public Media Media { get; set; }
        public string IMDbMovieId { get; set; }
        public int Year { get; set; }
        public double? RatingIMDb { get; set; }
        public double? UserIMDb { get; set; }
        public int EpisodeCount { get; set; } = 0;
        public ICollection<Episode> EpisodesList { get; set; } = new List<Episode>();
    }
}