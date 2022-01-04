using System.Collections.Generic;

namespace MoviesService.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Media> MediaCollection { get; set; } = new List<Media>();
    }
}
