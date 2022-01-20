using System.Collections.Generic;

namespace MoviesService.Services.IService
{
    public interface IGetEntityAndEntitiesService<T>
    {
        IEnumerable<T> Entities { get; }
        T GetEntity(int id);
    }
}
