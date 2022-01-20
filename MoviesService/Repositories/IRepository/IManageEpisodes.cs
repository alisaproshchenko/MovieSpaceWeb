using MoviesService.Models;

namespace MoviesService.Repositories.IRepository
{
    public interface IManageEpisodes
    {
        void AddEpisode(int seasonId);
        public void Edit(Episode entity);
        void Delete(int id);
    }
}
