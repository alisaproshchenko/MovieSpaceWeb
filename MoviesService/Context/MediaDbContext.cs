using System.Data.Entity;
using MoviesService.Models;

namespace MoviesService.Context
{
    public sealed class MediaDbContext : DbContext
    {
        public DbSet<Media> MediaTable { get; set; }
        public DbSet<Country> CountriesTable { get; set; }
        public DbSet<Types> TypesTable { get; set; }
        public DbSet<Seasons> SeasonsTable { get; set; }
        public DbSet<Genres> GenresTable { get; set; }
        public DbSet<Episode> EpisodeTable { get; set; }
        public DbSet<UsersToMedia> UsersToMediaTable { get; set; }
        public MediaDbContext() : base("MediaDbContext") {}
    }
}
