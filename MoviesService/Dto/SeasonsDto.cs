using System.Collections.Generic;
using MoviesService.Models;

namespace MoviesService.Dto
{
    public class SeasonsDto
    {
        public int Id { set; get; }
        public string Name { get; set; }
        public int? MediaId { get; set; }
        public Media Media { get; set; }
        public string IMDbMovieId { get; set; }
        public int Year { get; set; }
        public double? RatingIMDb { get; set; }
        public double? UserIMDb { get; set; }
        public ICollection<Episode> EpisodesList { get; set; } = new List<Episode>();
    }
}