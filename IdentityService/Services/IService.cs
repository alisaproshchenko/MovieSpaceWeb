using System.Collections.Generic;

namespace IdentityService.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        void AddUser(T item);
        void ChangeUserData(T item);
        void ChangePassword(T item);
        void UserBanToggle(T item);
        void AdminRightsToggle(T item);
        void DeleteUser(T item);
    }
}
