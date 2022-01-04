using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class UsersToMedia
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int MediaId { get; set; }
        [Required]
        public Media Media { get; set; }
        public bool Liked { get; set; } 
        public bool Watched { get; set; }
    }
}
