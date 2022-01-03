using System;
using System.Collections.Generic;

namespace IdentityService.Repository
{
    public interface IRepository<T> : IDisposable where  T : class 
    {
        IEnumerable<T> GetAll(); 
        T GetById(string id);
        T GetByUsername(string username);
        void Create(T item, string password);
        void Create(T item);
        void Update(T item); 
        void Delete(string id); 
        void Save();
    }
}
