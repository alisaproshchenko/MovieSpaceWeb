using System.Collections.Generic;

namespace MoviesService.Services.IService
{
    public interface IServices<T>
    {
        T GetEntity(int id);
        IEnumerable<T> Entities { get; }
        void Edit(T entity);
        void Delete(T entity);
    }
}
