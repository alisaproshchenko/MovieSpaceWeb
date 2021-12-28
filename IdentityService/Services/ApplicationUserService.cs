using System;
using System.Collections.Generic;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Repository;
using Microsoft.AspNet.Identity;

namespace IdentityService.Services
{
    public class ApplicationUserService : IService<ApplicationUserDto>
    {
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        private readonly ApplicationUserManager _manager;

        public ApplicationUserService(ApplicationUserManager manager)
        {
            _manager = manager;
            _applicationUserRepository = new ApplicationUserRepository(_manager);
        }

        public IEnumerable<ApplicationUserDto> GetAll()
        {
            var users = _applicationUserRepository.GetUsers();
            var userDtos = Mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            return userDtos;
            
        }

        public ApplicationUserDto Get(string id)
        {
            var user = _applicationUserRepository.GetUser(id);
            return Mapper.Map<ApplicationUserDto>(user);
        }

        public void AddUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Create(applicationUser, applicationUserDto.Password);
            _applicationUserRepository.Save();
        }

        public void ChangeUserData(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
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
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Delete(applicationUser.Id);
            _applicationUserRepository.Save();
        }
    }
}
