using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Banned { get; set; }

        public ApplicationUser() { }
    }
}
