namespace MoviesService.Services.IService
{
    public interface IMediaAddService<T>
    {
        void AddMedia(T entity, int typeId, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
