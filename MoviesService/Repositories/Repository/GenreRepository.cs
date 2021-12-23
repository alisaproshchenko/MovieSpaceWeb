using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Repositories.Repository
{
    public class GenreRepository : IMediaRepository<Genres>
    {
        public Genres GetItem { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<Genres> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task AddItem()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditItem(Genres item)
        {
            throw new System.NotImplementedException();
        }
    }
}
