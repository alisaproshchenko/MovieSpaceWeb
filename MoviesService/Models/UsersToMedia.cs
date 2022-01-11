using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class UsersToMedia
    {
        [Key]
        public int UserToMediaId { get; set; }
        public string ApplicationUserId { get; set; }
        public int MediaId { get; set; }
        public bool Liked { get; set; }
        public bool Watched { get; set; }
        public bool AddToWatch { get; set; }
        public DateTime Date { get; set; }
    }
}
