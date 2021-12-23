﻿namespace MoviesService.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MediaId { get; set; }
        public Media? Media { get; set; }
    }
}