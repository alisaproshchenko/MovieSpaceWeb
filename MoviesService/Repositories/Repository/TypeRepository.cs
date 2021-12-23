using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class TypeRepository : IMediaRepository<Types>
    {
        private readonly MediaDbContext _context;
        public TypeRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Types> Items => _context.TypesTable;

        public async Task<Types> GetItem(int id)
        {
            var type = await _context.TypesTable.FirstOrDefaultAsync(i => i.Id == id);
            return type;
        }

        public void AddItem(Types item)
        {
            _context.TypesTable.Add(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var type = _context.TypesTable.FirstOrDefault(t => t.Id == id);
            if (type != null) _context.TypesTable.Remove(type);
            _context.SaveChanges();
        }

        public void EditItem(Types item)
        {
            _context.TypesTable.AddOrUpdate(item);
            _context.SaveChanges();
        }
    }
}
