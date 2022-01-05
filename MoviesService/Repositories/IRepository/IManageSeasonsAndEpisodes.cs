namespace MoviesService.Repositories.IRepository
{
    public interface IManageSeasonsAndEpisodes
    {
        void AddSeason(int seriesId);
        void AddEpisode(int seasonId);
        void DeleteSeason(int id);
        void DeleteEpisode(int id);
    }
}
