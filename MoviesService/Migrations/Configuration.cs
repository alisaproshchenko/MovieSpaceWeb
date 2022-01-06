using System.Collections.Generic;
using MoviesService.Data;
using MoviesService.Models;

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

            context.MediaTable.AddOrUpdate(
                a => new { a.IMDbMovieId}, SedTop250IMDb.TestList.ToArray());

            context.SaveChanges();
        }
    }
}
