using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.Repository;
using IdentityService.Utilities;

namespace IdentityService.Services
{
    public class ApplicationUserService : IService<ApplicationUserDto>
    {
        private readonly IRepository<ApplicationUser> _applicationUserRepository;

            protected ApplicationUserService(IRepository<ApplicationUser> applicationUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
        }
        //AutoMapper requested 
        public void AddUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = AutoMap.Mapper.Map<ApplicationUser>(applicationUserDto);
            _applicationUserRepository.Create(applicationUser);
        }

        public void ChangeUserData(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _applicationUserRepository.GetUser(applicationUserDto.Id);
            userInDb.Name = applicationUserDto.Name;
            userInDb.Surname = applicationUserDto.Surname;
            userInDb.Email = applicationUserDto.Email;
            userInDb.PhoneNumber = applicationUserDto.PhoneNumber;
            userInDb.UserName = applicationUserDto.UserName;
            _applicationUserRepository.Update(userInDb);
        }

        public void ChangePassword(ApplicationUserDto applicationUserDto)
        {
            throw new System.NotImplementedException();
        }

        public void BanUser(ApplicationUserDto applicationUserDto)
        {
            throw new System.NotImplementedException();
        }

        public void GiveAdminRights(ApplicationUserDto applicationUserDto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteUser(ApplicationUserDto applicationUserDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
