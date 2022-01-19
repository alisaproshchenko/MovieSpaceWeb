using System.Collections.Generic;

namespace MoviesService.Services.IService
{
    public interface IServices<T>
    {
        T GetEntity(int id);
        IEnumerable<T> Entities { get; }
        void Delete(T entity);
    }
}
