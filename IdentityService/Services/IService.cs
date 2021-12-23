namespace IdentityService.Services
{
    public interface IService<T> where T : class
    {
        void AddUser(T item);
        void ChangeUserData(T item);
        void ChangePassword(T item);
        void BanUser(T item);
        void GiveAdminRights(T item);
        void DeleteUser(T item);
    }
}
