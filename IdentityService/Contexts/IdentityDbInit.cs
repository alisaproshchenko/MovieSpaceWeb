using System.Data.Entity;
using IdentityService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Contexts
{
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(IdentityContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var admin = new ApplicationUser {Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            var password = "ad46D_ewr3";
            manager.Create(admin, password);
            

        }
    }
}
