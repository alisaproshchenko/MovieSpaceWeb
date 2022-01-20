using MoviesService.Dto;

namespace MoviesService.Services.IService
{
    public interface IManageSeasonService
    {
        void AddSeason(int seriesId);
        public void Edit(SeasonsDto entity);
        void Delete(SeasonsDto entity);
    }
}
