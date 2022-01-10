using System;
using System.Collections.Generic;
using System.Linq;
using IdentityService.Contexts;
using IdentityService.Managers;
using IdentityService.Models;
using Microsoft.AspNet.Identity;

namespace IdentityService.Repository
{
    public class ApplicationUserRepository : IRepository<ApplicationUser>
    {
        private readonly IdentityContext _db;
        private readonly ApplicationUserManager _manager;

        public ApplicationUserRepository(ApplicationUserManager manager)
        {
            _manager = manager;
            _db = new IdentityContext();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _manager.Users;
        }

        public ApplicationUser GetById(string id)
        {
            return _db.Users.FirstOrDefault(u => u.Id.Equals(id));
        }
        public ApplicationUser GetByName(string username)
        {
            return _db.Users.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public void Create(ApplicationUser applicationUser, string password)
        {
            _manager.Create(applicationUser, password);
        }

        public void Create(ApplicationUser item) //user without password
        {
            _manager.Create(item);
        }

        public void Update(ApplicationUser applicationUser)
        {
            _db.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string id)
        {
            var applicationUser = _db.Users.FirstOrDefault(u => u.Id.Equals(id));
            if (applicationUser != null)
                _db.Users.Remove(applicationUser);
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
