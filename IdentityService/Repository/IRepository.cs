using System;
using System.Collections.Generic;

namespace IdentityService.Repository
{
    public interface IRepository<T> : IDisposable where  T : class 
    {
        IEnumerable<T> GetUsers(); 
        T GetUser(string id);
        T GetUserByUsername(string username);
        void Create(T item, string password); 
        void Update(T item); 
        void Delete(string id); 
        void Save();
    }
}
