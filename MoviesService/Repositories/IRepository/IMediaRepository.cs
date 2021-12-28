using System.Collections.Generic;

namespace MoviesService.Repositories.IRepository
{
     public interface IMediaRepository<T>
     {
         IEnumerable<T> Items { get; }
         T GetItem(int id);
         void AddItem(T item);
         void DeleteItem(int id);
         void EditItem(T item);
     }
}
