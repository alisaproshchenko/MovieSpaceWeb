using System.Data.Entity;
using MoviesService.Models;
using Newtonsoft.Json.Linq;

namespace MoviesService.Context
{
    public sealed class MediaDbContext : DbContext
    {
        public DbSet<Media> MediaTable { get; set; }
        public DbSet<Country> CountriesTable { get; set; }
        public DbSet<Types> TypesTable { get; set; }
        public DbSet<Seasons> SeasonsTable { get; set; }
        public DbSet<Genres> GenresTable { get; set; }
        public DbSet<UsersToMedia> UsersToMediaTable { get; set; }
        public MediaDbContext() : base("MediaDbContext") {}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>().HasMany(g => g.GenresCollection)
                        .WithMany(m => m.MediaCollection)
                        .Map(k => k.MapLeftKey("MediaId")
                        .MapRightKey("GenresId")
                        .ToTable("MediaGenres"));
            modelBuilder.Entity<Media>().HasMany(g => g.CountryCollection)
                .WithMany(m => m.MediaCollection)
                .Map(k => k.MapLeftKey("MediaId")
                    .MapRightKey("CountryId")
                    .ToTable("MediaCountry"));
        }
    }
}
