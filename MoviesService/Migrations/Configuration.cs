using System.Collections.Generic;
using IMDbApiLib;
using MoviesService.IMDbApi;
using MoviesService.Models;

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
            var apiLib = new ApiLib("k_ag12ki7h");

            var convertor = new ConvertorApiData();

            var dataApi = await apiLib.Top250MoviesAsync();

            var searchResults = dataApi.Items;

            for (var i = 1; i < 4; i++)
            {
                var movieData = await apiLib.TitleAsync(searchResults[i].Id);

                var model = new Media
                {
                    Id = i,
                    IMDbMovieId = movieData.Id,
                    Name = movieData.Title,
                    Poster = movieData.Image,
                    Year = convertor.StrToInt(movieData.Year),
                    Cast = convertor.Actors(movieData.ActorList),
                    Plot = movieData.Plot,
                    Budget = movieData.BoxOffice.Budget,
                    BoxOffice = movieData.BoxOffice.CumulativeWorldwideGross,
                    RatingIMDb = convertor.StrToDouble(movieData.IMDbRating),
                };







            }








        }
    }
}
