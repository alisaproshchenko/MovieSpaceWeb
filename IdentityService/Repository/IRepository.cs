﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Repository
{
    public interface IRepository<T> : IDisposable where  T : class 
    {
        IEnumerable<T> GetUsers(); 
        T GetUser(string id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(string id); 
        void Save();
    }
}
