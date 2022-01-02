using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class SeasonRepository : IMediaRepository<Seasons>
    {
        private readonly MediaDbContext _context;
        public SeasonRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Seasons> Entities => _context.SeasonsTable;

        public Seasons GetEntity(int id)
        {
            var season =  _context.SeasonsTable.FirstOrDefault(i => i.Id == id);
            return season;
        }

        public void Add(Seasons season)
        {
            _context.SeasonsTable.Add(season);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var season = _context.SeasonsTable.FirstOrDefault(t => t.Id == id);
            if (season != null) _context.SeasonsTable.Remove(season); 
            _context.SaveChanges();
        }

        public void Edit(Seasons season)
        {
            _context.SeasonsTable.AddOrUpdate(season);
            _context.SaveChanges();
        }
    }
}
