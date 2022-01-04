using System.Collections.Generic;
using IdentityService.UOW;

namespace IdentityService.Services
{
    public interface IService<T>
    {
        public UnitOfWork UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T Get(string id);
        T GetByUsername(string username);
        void AddUser(T item);
        void ChangeUserData(T item);
        void ChangePassword(T item);
        void UserBanToggle(T item);
        void AdminRightsToggle(T item);
        void DeleteUser(T item);
        IEnumerable<string> GetRoles(string username);
    }
}
