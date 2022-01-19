using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class TypeRepository : IMediaRepository<Types>, IAddSingleRepository<Types>, IEditSingleRepository<Types>
    {
        private readonly MediaDbContext _context;
        public TypeRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Types> Entities => _context.TypesTable;

        public Types GetEntity(int id)
        {
            var type =  _context.TypesTable.FirstOrDefault(i => i.Id == id);
            return type;
        }

        public void Add(Types entity)
        {
            _context.TypesTable.Add(entity); 
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var type = _context.TypesTable.FirstOrDefault(t => t.Id == id);
            if (type != null) _context.TypesTable.Remove(type);
            _context.SaveChanges();
        }

        public void Edit(Types entity)
        {
            _context.TypesTable.AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}
