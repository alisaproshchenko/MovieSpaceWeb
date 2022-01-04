namespace MoviesService.Repositories.IRepository
{
    public interface IAddSeasonRepository
    {
        void AddSeason(int seriesId);
        void AddEpisode(int seasonId);
    }
}
