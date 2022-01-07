using MoviesService.Data;

namespace MoviesService.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesService.Context.MediaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override async void Seed(MoviesService.Context.MediaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.MediaTable.AddRange(SeedTop250IMDb.TestList.ToArray());

            await context.SaveChangesAsync();
        }
    }
}
