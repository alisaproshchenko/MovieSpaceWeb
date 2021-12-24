using System;
using System.Collections.Generic;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Utilities;
using Microsoft.AspNet.Identity;

namespace IdentityService.Services
{
    public class ApplicationUserService : IService<ApplicationUserDto>
    {
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        private readonly ApplicationUserManager _manager;

        public ApplicationUserService(ApplicationUserManager manager)
        {
            //_manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new IdentityContext()));
            _manager = manager;
            _applicationUserRepository = new ApplicationUserRepository();
        }

        public IEnumerable<ApplicationUserDto> GetAll()
        {
            var users = _applicationUserRepository.GetUsers();
            var userDtos = AutoMap.Mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            return userDtos;
        }

        public void AddUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Create(applicationUser);
            _applicationUserRepository.Save();
        }

        public void ChangeUserData(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Update(applicationUser);
            _applicationUserRepository.Save();
        }

        public void ChangePassword(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _applicationUserRepository.GetUser(applicationUserDto.Id);
            _manager.RemovePassword(userInDb.Id);
            _manager.AddPassword(userInDb.Id, applicationUserDto.Password);
            _applicationUserRepository.Save();
        }

        public void UserBanToggle(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _applicationUserRepository.GetUser(applicationUserDto.Id);
            if (userInDb == null) 
                return;

            userInDb.Banned = applicationUserDto.Banned;
            _applicationUserRepository.Update(userInDb);
            _applicationUserRepository.Save();
        }

        public void AdminRightsToggle(ApplicationUserDto applicationUserDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Delete(applicationUser.Id);
            _applicationUserRepository.Save();
        }
    }
}
