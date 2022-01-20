using MoviesService.Models;

namespace MoviesService.Repositories.IRepository
{
    public interface IMediaManageRepository
    {
        void AddMedia(Media entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);

        public void EditMedia(Media media, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
        void Delete(int id);
    }
}
