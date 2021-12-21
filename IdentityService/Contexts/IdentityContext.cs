using IdentityService.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Contexts
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public IdentityContext() : base("IdentityDB")
        {
            
        }
    }
}
