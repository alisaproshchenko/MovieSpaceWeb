using IdentityService.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("IdentityDb") { }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
