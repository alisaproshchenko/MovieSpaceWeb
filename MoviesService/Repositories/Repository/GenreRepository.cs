using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class GenreRepository : IMediaRepository<Genres>
    {
        private readonly MediaDbContext _context;
        public GenreRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Genres> Items => _context.GenresTable;

        public Genres GetItem(int id)
        {
            var genres =  _context.GenresTable.FirstOrDefault(i => i.Id == id);
            return genres;
        }

        public void AddItem(Genres genre)
        {
            _context.GenresTable.Add(genre);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var genre = _context.GenresTable.FirstOrDefault(t => t.Id == id);
            if (genre != null) _context.GenresTable.Remove(genre);
            _context.SaveChanges();
        }

        public void EditItem(Genres genre)
        {
            _context.GenresTable.AddOrUpdate(genre);
            _context.SaveChanges();
        }
    }
}
