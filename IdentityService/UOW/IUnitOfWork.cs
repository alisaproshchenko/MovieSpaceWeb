using IdentityService.Managers;
using IdentityService.Models;
using IdentityService.Repository;

namespace IdentityService.UOW
{
    public interface IUnitOfWork
    {
        public IRepository<ApplicationUser> UserRepository { get; }
        public IRepository<ApplicationRole> RoleRepository { get; }
        public IRepository<AboutUs> AboutUsRepository { get; }
        public ApplicationRoleManager RoleManager { get; }
        public ApplicationUserManager UserManager { get; }
        public PasswordValidationRules PasswordValidation { get; }
    }
}