using System.ComponentModel.DataAnnotations;

namespace MoviesService.Models
{
    public class Types
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public string Name { get; set; }
        public Media Media { get; set; }
    }
}