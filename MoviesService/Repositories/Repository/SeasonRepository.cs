using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class SeasonRepository : IMediaRepository<Seasons>, IManageSeasonsAndEpisodes
    {
        private readonly MediaDbContext _context;
        public SeasonRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Seasons> Entities => _context.SeasonsTable.Include("EpisodesList");

        public Seasons GetEntity(int id)
        {
            var season =  _context.SeasonsTable.FirstOrDefault(i => i.Id == id);
            return season;
        }
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public void Edit(Seasons season)
        {
            _context.SeasonsTable.AddOrUpdate(season);
            _context.SaveChanges();
        }
        public void DeleteSeason(int id)
        {
            var season = _context.SeasonsTable.FirstOrDefault(t => t.Id == id);
            var media = _context.MediaTable.FirstOrDefault(x => x.Id == season.MediaId);
            --media.SeasonCount;
            _context.SeasonsTable.Remove(season);
            _context.SaveChanges();
        }

        public void DeleteEpisode(int id)
        {
            var episode = _context.EpisodeTable.FirstOrDefault(e => e.Id == id);
            var season = _context.SeasonsTable.FirstOrDefault(s => s.Id == episode.SeasonsId); 
            --season.EpisodeCount;
            _context.EpisodeTable.Remove(episode);
            _context.SaveChanges();
        }

        public void AddSeason(int seriesId)
        {
            var media = _context.MediaTable.FirstOrDefault(x => x.Id == seriesId);
            ++media.SeasonCount;
            var season = new Seasons()
            {
                Name = "Season" + media.SeasonCount.ToString(),
                Media = media
            };
            _context.SeasonsTable.Add(season);
            media.SeasonsList.Add(_context.SeasonsTable.FirstOrDefault(x => x.Id == season.Id));
            _context.SaveChanges();
        }

        public void AddEpisode(int seasonId)
        {
            var season = _context.SeasonsTable.FirstOrDefault(x => x.Id == seasonId);
            ++season.EpisodeCount;
            var episode = new Episode()
            {
                Name = "Episode" + season.EpisodeCount.ToString(),
                Seasons = season
            };
            season.EpisodesList.Add(
                _context.EpisodeTable.FirstOrDefault(x => x.Id == episode.Id));
            _context.EpisodeTable.Add(episode);
            _context.SaveChanges();
        }
    }
}
