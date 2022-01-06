using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class MediaRepository : IMediaRepository<Media>, IMediaAddRepository<Media>
    {
        private readonly MediaDbContext _context;
        public MediaRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Media> Entities => _context.MediaTable.Include("SeasonsList");
        public Media GetEntity(int id)
        {
            var media =  _context.MediaTable.FirstOrDefault(i => i.Id == id);
            return media;
        }

        public void Add(Media media)
        {
            _context.MediaTable.AddOrUpdate(media);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var media = _context.MediaTable.Include("SeasonsList").FirstOrDefault(t => t.Id == id);
            if (media.SeasonsList != null)
            {
                foreach (var season in media.SeasonsList )
                {
                    if (season.EpisodesList != null)
                    {
                        foreach (var episode in season.EpisodesList)
                        {
                            _context.EpisodeTable.Remove(episode);
                        }
                    }

                    _context.SeasonsTable.Remove(season);
                }
            }
            if (media != null) _context.MediaTable.Remove(media);
            _context.SaveChanges();
        }

        public void Edit(Media media)
        {
            var m = _context.MediaTable.Include("SeasonsList").FirstOrDefault(t => t.Id == media.Id);
            m.Name = media.Name;
            m.Plot = media.Plot;
            m.Year = media.Year;
            _context.MediaTable.AddOrUpdate(m);
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
    }
}
