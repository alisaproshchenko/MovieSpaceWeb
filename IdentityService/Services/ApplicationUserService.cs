using System;
using IdentityService.Contexts;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityService.Services
{
    public class ApplicationUserService : IService<ApplicationUserDto>
    {
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        private readonly ApplicationUserManager manager;

        protected ApplicationUserService(IRepository<ApplicationUser> applicationUserRepository)
        {
            manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new IdentityContext()));
            _applicationUserRepository = applicationUserRepository;
        }

        public void AddUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Create(applicationUser);
        }

        public void ChangeUserData(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Update(applicationUser);
        }

        public void ChangePassword(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _applicationUserRepository.GetUser(applicationUserDto.Id);
            manager.RemovePassword(userInDb.Id);
            manager.AddPassword(userInDb.Id, applicationUserDto.Password);
        }

        public void UserBanToggle(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _applicationUserRepository.GetUser(applicationUserDto.Id);
            if (userInDb != null)
            {
                userInDb.Banned = applicationUserDto.Banned;
                _applicationUserRepository.Update(userInDb);
            }
        }

        public void AdminRightsToggle(ApplicationUserDto applicationUserDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Delete(applicationUser.Id);
        }
    }
}
