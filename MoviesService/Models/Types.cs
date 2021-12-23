using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesService.Models
{
    public class Types
    {
        [Key]
        [ForeignKey("Media")]
        public int Id { set; get; }
        [Required]
        public string Name { get; set; }
        public Media Media { get; set; }
    }
}