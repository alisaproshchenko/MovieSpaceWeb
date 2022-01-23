using MoviesService.Dto;

namespace MoviesService.Services.IService
{
    public interface IMediaManageService
    {
        void AddMedia(MediaDto entity, int? selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
        public void EditMedia(MediaDto entity, int? selectedType, int[] selectedGenresIds, int[] selectedCountriesIds, int[] seasons);
        void Delete(MediaDto entity, string userId);
    }
}
