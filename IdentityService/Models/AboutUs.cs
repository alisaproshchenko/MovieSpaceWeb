using System.ComponentModel.DataAnnotations;

namespace IdentityService.Models
{
    public class AboutUs
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoLink { get; set; }
        public string ProjectRole { get; set; }
    }
}
