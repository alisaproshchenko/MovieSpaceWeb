using MoviesService.Models;

namespace MoviesService.Repositories.IRepository
{
    public interface IManageSeasons
    {
        void AddSeason(int seriesId);
        public void Edit(Seasons entity, int[] episodes);
        void Delete(int id);
    }
}
