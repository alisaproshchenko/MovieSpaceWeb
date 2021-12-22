using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Repositories.IRepository
{
     public interface IMediaRepository<T>
     {
         T GetItem { get; set; }
         IEnumerable<T> Items { get; set; }
         Task AddItem();
         Task DeleteItem(int id);
         Task EditItem(T item);
     }
}
