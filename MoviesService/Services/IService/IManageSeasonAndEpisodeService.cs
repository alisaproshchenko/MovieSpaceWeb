namespace MoviesService.Services.IService
{
    public interface IManageSeasonAndEpisodeService
    {
        void AddSeason(int seriesId);
        void AddEpisode(int seasonId);
        void DeleteSeason(int id);
        void DeleteEpisode(int id);
    }
}
