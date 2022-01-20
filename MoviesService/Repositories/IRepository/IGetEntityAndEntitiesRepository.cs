using System.Collections.Generic;

namespace MoviesService.Repositories.IRepository
{
    public interface IGetEntityAndEntitiesRepository<T>
    {
        IEnumerable<T> Entities { get; }
        T GetEntity(int id);
    }
}
