﻿using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int MediaId { get; set; }
        public Media? Media { get; set; }
    }
}