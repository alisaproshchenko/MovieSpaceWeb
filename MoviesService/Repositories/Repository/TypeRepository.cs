using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesService.Repositories.Repository
{
    public class TypeRepository : IMediaRepository<Types>
    {
        public Types GetItem { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public IEnumerable<Types> Items { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public Task AddItem()
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditItem(Types item)
        {
            throw new System.NotImplementedException();
        }
    }
}
