using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;

namespace MoviesService.Repositories.Repository
{
    public class CountryRepository : IMediaRepository<Country>
    {
        public Country GetItem { get; set; }
        public IEnumerable<Country> Items { get; set; }
        public Task AddItem()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditItem(Country item)
        {
            throw new System.NotImplementedException();
        }
    }
}
