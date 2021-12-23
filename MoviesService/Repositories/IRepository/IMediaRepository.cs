﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Repositories.IRepository
{
     public interface IMediaRepository<T>
     {
         IEnumerable<T> Items { get; }
         Task<T> GetItem(int id);
         void AddItem(T item);
         void DeleteItem(int id);
         void EditItem(T item);
     }
}
