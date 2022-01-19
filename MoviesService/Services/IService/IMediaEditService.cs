using MoviesService.Dto;

namespace MoviesService.Services.IService
{
    public interface IMediaEditService
    {
        public void EditMedia(MediaDto media, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
