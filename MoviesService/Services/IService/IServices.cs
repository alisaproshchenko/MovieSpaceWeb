using System.Collections.Generic;

namespace MoviesService.Services.IService
{
    public interface IServices<T>
    {
        T GetItem(int id);
        IEnumerable<T> Items { get; }
        void AddItem(T item);
        void EditItem(T item);
        void DeleteItem(T item);
    }
}
