using MoviesService.Models;

namespace MoviesService.Repositories.IRepository
{
    public interface IMediaEditRepository
    {
        public void EditMedia(Media media, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds);
    }
}
