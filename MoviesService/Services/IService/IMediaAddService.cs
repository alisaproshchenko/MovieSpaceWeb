namespace MoviesService.Services.IService
{
    public interface IMediaAddService<T>
    {
        void AddMedia(T entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
