using System;
using System.Collections.Generic;
using System.Linq;
using IdentityService.Contexts;
using IdentityService.Models;

namespace IdentityService.Repository
{
    class ApplicationUserRepository : IRepository<ApplicationUser>
    {
        private readonly IdentityContext _db;

        public ApplicationUserRepository()
        {
            _db = new IdentityContext();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _db.Users;
        }

        public ApplicationUser GetUser(string id)
        {
            return _db.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void Create(ApplicationUser applicationUser)
        {
            _db.Users.Add(applicationUser);
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
