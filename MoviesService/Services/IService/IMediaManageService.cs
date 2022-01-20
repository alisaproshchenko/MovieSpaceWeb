using MoviesService.Dto;
using MoviesService.Models;

namespace MoviesService.Services.IService
{
    public interface IMediaManageService
    {
        void AddMedia(MediaDto entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
        public void EditMedia(MediaDto entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
        void Delete(MediaDto entity);
    }
}
