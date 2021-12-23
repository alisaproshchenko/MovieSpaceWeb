using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class GenreRepository : IMediaRepository<Genres>
    {
        private readonly MediaDbContext _context;
        public GenreRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Genres> Items => _context.GenresTable;

        public async Task<Genres> GetItem(int id)
        {
            var season = await _context.GenresTable.FirstOrDefaultAsync(i => i.Id == id);
            return season;
        }

        public void AddItem(Genres genre)
        {
            _context.GenresTable.Add(genre);
            _context.SaveChanges();
        }

        public void DeleteItem(Genres genre)
        {
            _context.GenresTable.Remove(genre);
            _context.SaveChanges();
        }

        public void EditItem(Genres genre)
        {
            _context.GenresTable.AddOrUpdate(genre);
            _context.SaveChanges();
        }
    }
}
