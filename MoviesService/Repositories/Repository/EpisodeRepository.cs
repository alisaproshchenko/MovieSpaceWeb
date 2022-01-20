using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;
using MoviesService.Models;
using MoviesService.Repositories.IRepository;

namespace MoviesService.Repositories.Repository
{
    public class EpisodeRepository : IManageEpisodes, IGetEntityAndEntitiesRepository<Episode>
    {
        private readonly MediaDbContext _context;
        public EpisodeRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Episode> Entities => _context.EpisodeTable;

        public Episode GetEntity(int id)
        {
            var season = _context.EpisodeTable.FirstOrDefault(i => i.Id == id);
            return season;
        }
        public void Delete(int id)
        {
            var episode = _context.EpisodeTable.FirstOrDefault(e => e.Id == id);
            var season = _context.SeasonsTable.FirstOrDefault(s => s.Id == episode.SeasonsId);
            --season.EpisodeCount;
            _context.EpisodeTable.Remove(episode);
            _context.SaveChanges();
        }
        public void Edit(Episode season)
        {
            _context.EpisodeTable.AddOrUpdate(season);
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
