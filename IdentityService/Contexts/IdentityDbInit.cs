using System;
using System.Data.Entity;
using IdentityService.Managers;
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
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var role1 = new ApplicationRole {Name = "Administrator", Description = "Manages users and movies"};
            var role2 = new ApplicationRole {Name = "User", Description = "Uses information about movies"};

            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser {Email = "cooladministrator@mail.ru", UserName = "cooladministrator" };
            var password = "ohMyPassword123";
            var result = manager.Create(admin, password);

            if (!result.Succeeded) throw new Exception();

            manager.AddToRole(admin.Id, role1.Name);
            manager.AddToRole(admin.Id, role2.Name);

        }
    }
}
