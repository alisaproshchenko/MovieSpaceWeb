using System.Collections.Generic;
using IdentityService.UOW;

namespace IdentityService.Services
{
    public interface IAboutUsService<T>
    {
        public UnitOfWork UnitOfWork { get; }
        IEnumerable<T> GetAll();
        T Get(string id);
        void Add(T item);
        void Change(T item);
        void Delete(string id);
    }
}
