using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Repositories.Repository
{
    public class SeasonRepository : IMediaRepository<Seasons>
    {
        public Seasons GetItem { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<Seasons> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task AddItem()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditItem(Seasons item)
        {
            throw new System.NotImplementedException();
        }
    }
}
