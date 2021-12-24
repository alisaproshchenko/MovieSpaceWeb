using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Services;
using Microsoft.AspNet.Identity;
using Ninject.Modules;
using Ninject.Web.Common;

namespace IdentityService.Utilities
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<ApplicationUser>>().To<ApplicationUserRepository>().InRequestScope();
            Bind<IService<ApplicationUserDto>>().To<ApplicationUserService>().InRequestScope();
            Bind<UserManager<ApplicationUser>>().To<ApplicationUserManager>().InRequestScope();
        }
    }
}
