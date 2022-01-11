using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using IdentityService.Dto;
using IdentityService.Models;
using IdentityService.UOW;
using Microsoft.AspNet.Identity;

namespace IdentityService.Services
{
    public class ApplicationUserService : IService<ApplicationUserDto>
    {
        private readonly UnitOfWork _uow;
        public UnitOfWork UnitOfWork => _uow;

        public ApplicationUserService()
        {
            _uow = new UnitOfWork();
        }

        public IEnumerable<ApplicationUserDto> GetAll()
        {
            var users = _uow.UserRepository.GetAll();
            var userDtos = Mapper.Map<IEnumerable<ApplicationUserDto>>(users);
            return userDtos;
        }

        public ApplicationUserDto Get(string id)
        {
            var user = _uow.UserRepository.GetById(id);
            return Mapper.Map<ApplicationUserDto>(user);
        }

        public ApplicationUserDto GetByUsername(string username)
        {
            var user = _uow.UserRepository.GetByName(username);
            return Mapper.Map<ApplicationUserDto>(user);
        }

        public void AddUser(ApplicationUserDto applicationUserDto) //with a "User" role
        {
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
            _uow.UserRepository.Create(applicationUser, applicationUserDto.Password);
            _uow.UserRepository.Save();

            const string userRole = "User";
            var newUserId = _uow.UserRepository.GetByName(applicationUser.UserName).Id;
            _uow.UserManager.AddToRole(newUserId, userRole);

            _uow.UserRepository.Save();
        }

        public void ChangeUserData(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
            _uow.UserRepository.Update(applicationUser);
            _uow.UserRepository.Save();
        }

        public void ChangePassword(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _uow.UserRepository.GetByName(applicationUserDto.UserName);
            _uow.UserManager.RemovePassword(userInDb.Id);
            _uow.UserManager.AddPassword(userInDb.Id, applicationUserDto.Password);
            _uow.UserRepository.Save();
        }

        public void UserBanToggle(ApplicationUserDto applicationUserDto)
        {
            var userInDb = _uow.UserRepository.GetByName(applicationUserDto.UserName);
            if (userInDb == null)
                return;

            userInDb.Banned = !userInDb.Banned;
            _uow.UserRepository.Update(userInDb);
            _uow.UserRepository.Save();
        }

        public void AdminRightsToggle(ApplicationUserDto applicationUserDto)
        {
            var userId = _uow.UserRepository.GetByName(applicationUserDto.UserName).Id;

            if (IsAdministrator(userId))
                _uow.UserManager.RemoveFromRole(userId, "Administrator");
            else
                _uow.UserManager.AddToRole(userId, "Administrator");

            _uow.UserRepository.Save();
        }

        public void DeleteUser(ApplicationUserDto applicationUserDto)
        {
            var applicationUser = Mapper.Map<ApplicationUser>(applicationUserDto);
            _uow.UserRepository.Delete(applicationUser.Id);
            _uow.UserRepository.Save();
        }

        public IEnumerable<string> GetRoles(string username)
        {
            var userId = _uow.UserRepository.GetByName(username).Id;
            return _uow.UserManager.GetRoles(userId);
        }

        public bool IsAdministrator(string userId)
        {
            return _uow.UserManager.GetRoles(userId).Contains("Administrator");
        }

        public IEnumerable<string> Validate(string password)
        {
            var errors = new List<string>();
            if(password.Length < _uow.PasswordValidation.RequiredLength)
                errors.Add($"The minimum length of password is {_uow.PasswordValidation.RequiredLength} characters");

            if (_uow.PasswordValidation.RequireDigit)
            {
                if (!password.ToCharArray().Any(char.IsDigit))
                    errors.Add("At least one digit is needed in password");
            }

            if (_uow.PasswordValidation.RequireUppercase)
            {
                if (!password.ToCharArray().Any(char.IsUpper))
                    errors.Add("At least one character in upper case is needed in password");
            }

            if (_uow.PasswordValidation.RequireLowercase)
            {
                if (!password.ToCharArray().Any(char.IsLower))
                    errors.Add("At least one character in lower case is needed in password");
            }

            if (_uow.PasswordValidation.RequireNonLetterOrDigit)
            {
                if (password.ToCharArray().All(char.IsLetterOrDigit))
                    errors.Add("At least one non-digit and non-letter character is needed in password");
            }

            return errors;
        }
    }
}
