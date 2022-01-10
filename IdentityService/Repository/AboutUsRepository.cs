using IdentityService.Contexts;
using IdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityService.Repository
{
    public class AboutUsRepository : IRepository<AboutUs>
    {
        private readonly IdentityContext _db;
        public AboutUsRepository(IdentityContext context) => _db = context;

        public void Create(AboutUs item, string password)
        {
            _db.AboutUs.Add(item);
            _db.SaveChanges();
        }

        public void Create(AboutUs item)
        {
            _db.AboutUs.Add(item);
            _db.SaveChanges();
        }

        public void Delete(string id)
        {
            var aboutUsInDb = _db.AboutUs.FirstOrDefault(a => a.Id.Equals(id));
            if (aboutUsInDb != null)
                _db.AboutUs.Remove(aboutUsInDb);
        }

        public IEnumerable<AboutUs> GetAll()
        {
            return _db.AboutUs;
        }

        public AboutUs GetById(string id)
        {
            return _db.AboutUs.FirstOrDefault(a => a.Id.Equals(id));
        }

        public AboutUs GetByName(string username)
        {
            return _db.AboutUs.FirstOrDefault(u => u.Name.Equals(username));
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(AboutUs item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
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
