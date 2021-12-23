using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityService.Contexts;
using IdentityService.Models;

namespace IdentityService.Repository
{
    class ApplicationUserRepository : IRepository<ApplicationUser>
    {
        private readonly IdentityContext identityContext;

        public ApplicationUserRepository()
        {
            identityContext = new IdentityContext();
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return identityContext.Users;
        }

        public ApplicationUser GetUser(string id)
        {
            return identityContext.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void Create(ApplicationUser applicationUser)
        {
            identityContext.Users.Add(applicationUser);
        }

        public void Update(ApplicationUser applicationUser)
        {
            identityContext.Entry(applicationUser).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string id)
        {
            ApplicationUser applicationUser = identityContext.Users.FirstOrDefault(u => u.Id.Equals(id));
            if (applicationUser != null)
                identityContext.Users.Remove(applicationUser);
        }

        public void Save()
        {
            identityContext.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    identityContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
