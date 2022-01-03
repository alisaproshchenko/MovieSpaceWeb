namespace MoviesService.Repositories.IRepository
{
    public interface IMediaAddRepository<T>
    {
        void AddMedia(T entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
