using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IMDbApiLib.Models;

namespace MoviesService.Models
{
    public class Genres
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Media> MediaCollection { get; set; } = new List<Media>(); }
}