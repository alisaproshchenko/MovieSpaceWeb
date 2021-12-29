using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Media> MediaCollection { get; set; } = new List<Media>();
    }
}