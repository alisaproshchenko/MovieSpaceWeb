namespace MoviesService.Repositories.IRepository
{
    public interface IMediaAddRepository<T>
    {
        void AddMedia(T entity, int type, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
