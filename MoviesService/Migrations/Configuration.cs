using MoviesService.Data;

namespace MoviesService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

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

            var seedData = new SedTop250IMDb();

            var test = await seedData.GetSearchAsynTask();

            context.MediaTable.AddOrUpdate(
                a => new { a.Id}, test.ToArray());

            context.SaveChanges();
        }
    }
}
