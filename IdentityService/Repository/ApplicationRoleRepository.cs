using System;
using System.Collections.Generic;
using System.Linq;
using IdentityService.Contexts;
using IdentityService.Managers;
using IdentityService.Models;
using Microsoft.AspNet.Identity;

namespace IdentityService.Repository
{
    public class ApplicationRoleRepository : IRepository<ApplicationRole>
    {
        private readonly IdentityContext _db;
        private readonly ApplicationRoleManager _manager;

        public ApplicationRoleRepository(ApplicationRoleManager manager)
        {
            _manager = manager;
            _db = new IdentityContext();
        }
        public IEnumerable<ApplicationRole> GetAll()
        {
            return _manager.Roles;
        }

        public ApplicationRole GetById(string id)
        {
            return _manager.Roles.FirstOrDefault(x => x.Id == id);
        }

        public ApplicationRole GetByUsername(string name) // by name of role
        {
            return _manager.Roles.FirstOrDefault(x => x.Name == name);
        }

        public void Create(ApplicationRole item, string password) //useless for creating roles
        {
            throw new NotImplementedException();
        }

        public void Create(ApplicationRole item)
        {
            _manager.Create(item);
        }

        public void Update(ApplicationRole item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string id)
        {
            _manager.Delete(GetById(id));
        }

        public void Save()
        {
            _db.SaveChanges();
        }
        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
