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
        public IEnumerable<Media> Entities => _context.MediaTable;
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
            var media = _context.MediaTable.FirstOrDefault(t => t.Id == id);
            if (media != null) _context.MediaTable.Remove(media);
            _context.SaveChanges();
        }

        public void Edit(Media media)
        {
            _context.MediaTable.AddOrUpdate(media);
            _context.SaveChanges();
        }

        public void AddMedia(Media entity, int type, int[] selectedGenresIds, int[] selectedCountriesIds)
        {
            entity.Types = _context.TypesTable.FirstOrDefault(x => x.Id == type);
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
