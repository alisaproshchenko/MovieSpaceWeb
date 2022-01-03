using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
        public ApplicationRole() { }
    }
}
