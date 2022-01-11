using IdentityService.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IdentityService.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext() : base("IdentityDb") { }
        public DbSet<AboutUs> AboutUs { get; set; }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
