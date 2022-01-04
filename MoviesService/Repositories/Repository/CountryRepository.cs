using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;

namespace MoviesService.Repositories.Repository
{
    public class CountryRepository : IMediaRepository<Country>
    {
        private readonly MediaDbContext _context;
        public CountryRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Country> Entities => _context.CountriesTable;

        public Country GetEntity(int id)
        {
            var country = _context.CountriesTable.FirstOrDefault(i => i.Id == id);
            return country;
        }

        public void Add(Country entity)
        {
            _context.CountriesTable.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var country = _context.CountriesTable.FirstOrDefault(t => t.Id == id);
            if (country != null) _context.CountriesTable.Remove(country);
            _context.SaveChanges();
        }

        public void Edit(Country entity)
        {
            _context.CountriesTable.AddOrUpdate(entity);
            _context.SaveChanges();
        }
    }
}
