﻿using System.Collections.Generic;

namespace MoviesService.Repositories.IRepository
{
     public interface IMediaRepository<T>
     {
         IEnumerable<T> Entities { get; }
         T GetEntity(int id);
         void Add(T entity);
         void Delete(int id);
         void Edit(T entity);
     }
}
