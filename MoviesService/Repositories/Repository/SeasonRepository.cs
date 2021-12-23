using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class SeasonRepository : IMediaRepository<Seasons>
    {
        private readonly MediaDbContext _context;
        public SeasonRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Seasons> Items => _context.SeasonsTable;

        public async Task<Seasons> GetItem(int id)
        {
            var season = await _context.SeasonsTable.FirstOrDefaultAsync(i => i.Id == id);
            return season;
        }

        public void AddItem(Seasons season)
        {
            _context.SeasonsTable.Add(season);
            _context.SaveChanges();
        }

        public void DeleteItem(Seasons season)
        {
            _context.SeasonsTable.Remove(season);
            _context.SaveChanges();
        }

        public void EditItem(Seasons season)
        {
            _context.SeasonsTable.AddOrUpdate(season);
            _context.SaveChanges();
        }
    }
}
