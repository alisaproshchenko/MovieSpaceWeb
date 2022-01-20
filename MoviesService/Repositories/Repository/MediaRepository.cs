using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class MediaRepository : IMediaManageRepository, IGetEntityAndEntitiesRepository<Media>
    {
        private readonly MediaDbContext _context;
        public MediaRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Media> Entities => _context.MediaTable.Include("SeasonsList");
        public Media GetEntity(int id)
        {
            var media =  _context.MediaTable.Include("Types").Include("GenresCollection").Include("SeasonsList").Include("CountryCollection").FirstOrDefault(i => i.Id == id);
            return media;
        }

        public void Delete(int id)
        {
            var media = _context.MediaTable.Include("SeasonsList").FirstOrDefault(t => t.Id == id);
            if (media.SeasonsList != null)
            {
                for (var seasonIndex = 0; seasonIndex < media.SeasonCount; ++seasonIndex )
                {
                    var seasonId = media.SeasonsList.ElementAt(index:0).Id;
                    var season =
                        _context.SeasonsTable.Include("EpisodesList").FirstOrDefault(x => x.Id == seasonId);
                    if (season.EpisodesList != null)
                    {
                        for (var episodeIndex = 0; episodeIndex < season?.EpisodeCount; ++episodeIndex)
                        {
                            _context.EpisodeTable.Remove(season.EpisodesList.ElementAt(index:0));
                        }
                    }

                    _context.SeasonsTable.Remove(season);
                }
            }
            if (media != null) _context.MediaTable.Remove(media);
            _context.SaveChanges();
        }

        public void AddMedia(Media entity, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            entity.Types = _context.TypesTable.FirstOrDefault(x => x.Id == selectedType);
            foreach (var id in selectedGenresIds)
            {
                entity.GenresCollection.Add(_context.GenresTable.FirstOrDefault(x => x.Id == id));
            }
            foreach (var id in selectedCountriesIds)
            {
                entity.CountryCollection.Add(_context.CountriesTable.FirstOrDefault(x => x.Id == id));
            }
            _context.MediaTable.AddOrUpdate(entity);
            _context.SaveChanges();
        }

        public Media SearchMedia(string searchData)
        {
            var model = _context.MediaTable.Include("Types").Include("GenresCollection").Include("CountryCollection").Include("SeasonsList").FirstOrDefault(x => x.Name == searchData);
            return model;
        }

        public void EditMedia(Media media, int selectedType, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            var m = _context.MediaTable.Include("SeasonsList").FirstOrDefault(t => t.Id == media.Id);
            m.Name = media.Name;
            m.Plot = media.Plot;
            m.Year = media.Year;
            m.Types = _context.TypesTable.FirstOrDefault(x => x.Id == selectedType);
            m.GenresCollection.Clear();
            m.CountryCollection.Clear();
            foreach (var id in selectedGenresIds)
            {
                m.GenresCollection.Add(_context.GenresTable.FirstOrDefault(x => x.Id == id));
            }
            foreach (var id in selectedCountriesIds)
            {
                m.CountryCollection.Add(_context.CountriesTable.FirstOrDefault(x => x.Id == id));
            }
            _context.MediaTable.AddOrUpdate(m);
            _context.SaveChanges();
        }
    }
}
