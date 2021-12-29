﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public List<Episode> EpisodesList { get; set; } = new List<Episode>();

    }
}