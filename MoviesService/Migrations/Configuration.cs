using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        protected override void Seed(MoviesService.Context.MediaDbContext context)
        {
            var apiLib = new ApiLib("k_q2sbygme");
            var convertor = new ConvertorApiData();
            var dataApi = Task.Run(() => apiLib.Top250MoviesAsync()).Result;

            var searchResults = dataApi.Items;

            for (var i = 1; i < 4; i++)
            {
                var movieData = Task.Run(() => apiLib.TitleAsync(searchResults[i].Id)).Result;

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
                    LinkEmbed = movieData.Trailer.LinkEmbed,
                    Types = context.TypesTable.FirstOrDefault(x => x.Name == movieData.Type),
                };

                var genresList = convertor.Genres(movieData.GenreList);
                var countriesList = convertor.Countries(movieData.Countries);
                foreach (var genre in genresList)
                {
                    model.GenresCollection.Add(context.GenresTable.FirstOrDefault(x => x.Name == genre.Name));
                }

                foreach (var country in countriesList)
                {
                    model.CountryCollection.Add(context.CountriesTable.FirstOrDefault(x => x.Name == country.Name));
                }

                context.MediaTable.AddOrUpdate(
                    a => new { a.IMDbMovieId }, model);
            }
            context.SaveChanges();
        }
    }
}
