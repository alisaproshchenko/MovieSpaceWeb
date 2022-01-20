using MoviesService.Dto;

namespace MoviesService.Services.IService
{
    public interface IManageEpisodeService
    {
        void AddEpisode(int seasonId);
        public void Edit(EpisodeDto entity);
        void Delete(EpisodeDto entity);
    }
}
