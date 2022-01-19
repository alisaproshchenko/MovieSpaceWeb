using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class GenreRepository : IMediaRepository<Genres>, IAddSingleRepository<Genres>, IEditSingleRepository<Genres>
    {
        private readonly MediaDbContext _context;
        public GenreRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Genres> Entities => _context.GenresTable;

        public Genres GetEntity(int id)
        {
            var genres =  _context.GenresTable.FirstOrDefault(i => i.Id == id);
            return genres;
        }

        public void Add(Genres entity)
        {
            _context.GenresTable.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var genre = _context.GenresTable.FirstOrDefault(t => t.Id == id);
            if (genre != null) _context.GenresTable.Remove(genre);
            _context.SaveChanges();
        }

        public void Edit(Genres entity)
        {
            _context.GenresTable.AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}
