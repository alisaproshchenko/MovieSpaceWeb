using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using MoviesService.Context;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;

namespace MoviesService.Repositories.Repository
{
    public class CountryRepository : IMediaRepository<Country>
    {
        private readonly MediaDbContext _context;
        public CountryRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Country> Items => _context.CountriesTable;

        public async Task<Country> GetItem(int id)
        {
            var country = await _context.CountriesTable.FirstOrDefaultAsync(i => i.Id == id);
            return country;
        }

        public void AddItem(Country country)
        {
            _context.CountriesTable.Add(country);
            _context.SaveChanges();
        }

        public void DeleteItem(Country country)
        {
            _context.CountriesTable.Remove(country);
            _context.SaveChanges();
        }

        public void EditItem(Country country)
        {
            _context.CountriesTable.AddOrUpdate(country);
            _context.SaveChanges();
        }
    }
}
