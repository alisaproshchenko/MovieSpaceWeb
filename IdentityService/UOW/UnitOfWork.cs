using IdentityService.Contexts;
using IdentityService.Managers;
using IdentityService.Models;
using IdentityService.Repository;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.UOW
{
    public class UnitOfWork
    {
        private readonly IdentityContext _db;
        private ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        private IRepository<ApplicationRole> _roleRepository;
        private IRepository<ApplicationUser> _userRepository;
        private IRepository<AboutUs> _aboutUsRepository;

        public UnitOfWork()
        {
            _db = new IdentityContext();
        }

        public IRepository<ApplicationUser> UserRepository => 
            _userRepository ??= new ApplicationUserRepository(UserManager);
        public IRepository<ApplicationRole> RoleRepository =>
            _roleRepository ??= new ApplicationRoleRepository(RoleManager);
        public IRepository<AboutUs> AboutUsRepository =>
            _aboutUsRepository ??= new AboutUsRepository(_db);

        public ApplicationRoleManager RoleManager =>
            _roleManager ??= new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
        public ApplicationUserManager UserManager =>
            _userManager ??= new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
    }
}
