using System.Linq;
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
            //var apiLib = new ApiLib("k_q2sbygme");
            //var convertor = new ConvertorApiData();
            //var dataApi = Task.Run(() => apiLib.Top250MoviesAsync()).Result;
            //var searchResults = dataApi.Items;

            //for (var i = 240; i < 250; ++i)
            //{
            //    var id = i;
            //    var movieData = Task.Run(() => apiLib.TitleAsync(searchResults[id].Id)).Result;
            //    var model = new Media
            //    {
            //        Id = i,
            //        IMDbMovieId = movieData.Id,
            //        Name = movieData.Title,
            //        Poster = movieData.Image,
            //        Year = convertor.StrToInt(movieData.Year),
            //        Cast = convertor.Actors(movieData.ActorList),
            //        Plot = movieData.Plot,
            //        Budget = movieData.BoxOffice.Budget,
            //        BoxOffice = movieData.BoxOffice.CumulativeWorldwideGross,
            //        RatingIMDb = convertor.StrToDouble(movieData.IMDbRating),
            //        Types = context.TypesTable.FirstOrDefault(x => x.Name == movieData.Type)
            //    };
            //    var genresList = convertor.Genres(movieData.GenreList);
            //    var countriesList = convertor.Countries(movieData.Countries);
            //    foreach (var genre in genresList)
            //    {
            //        model.GenresCollection.Add(context.GenresTable.FirstOrDefault(x => x.Name == genre.Name));
            //    }

            //    foreach (var country in countriesList)
            //    {
            //        model.CountryCollection.Add(context.CountriesTable.FirstOrDefault(x => x.Name == country.Name));
            //    }

            //    context.MediaTable.AddOrUpdate(
            //        a => new { a.IMDbMovieId }, model);
            //}
            //context.SaveChanges();

            //var apiLib = new ApiLib("k_jsvg94yx");
            //var convertor = new ConvertorApiData();
            //var dataApi = Task.Run(() => apiLib.Top250TVsAsync()).Result;

            //var searchResults = dataApi.Items;

            //for (var i = 60; i < 61; i++)
            //{
            //    var id = i;
            //    var movieData = Task.Run(() => apiLib.TitleAsync(searchResults[id].Id)).Result;

            //    var model = new Media
            //    {
            //        IMDbMovieId = movieData.Id,
            //        Name = movieData.Title,
            //        Poster = movieData.Image,
            //        Year = convertor.StrToInt(movieData.Year),
            //        Cast = convertor.Actors(movieData.ActorList),
            //        Plot = movieData.Plot,
            //        Budget = movieData.BoxOffice.Budget,
            //        BoxOffice = movieData.BoxOffice.CumulativeWorldwideGross,
            //        RatingIMDb = convertor.StrToDouble(movieData.IMDbRating),
            //        Types = context.TypesTable.FirstOrDefault(x => x.Name == "Series")
            //    };

            //    var genresList = convertor.Genres(movieData.GenreList);
            //    var countriesList = convertor.Countries(movieData.Countries);
            //    foreach (var genre in genresList)
            //    {
            //        model.GenresCollection.Add(context.GenresTable.FirstOrDefault(x => x.Name == genre.Name));
            //    }

            //    foreach (var country in countriesList)
            //    {
            //        model.CountryCollection.Add(context.CountriesTable.FirstOrDefault(x => x.Name == country.Name));
            //    }


            //    for (var j = 0; j < movieData.TvSeriesInfo.Seasons.Count; ++j)
            //    {
            //        ++model.SeasonCount;
            //        var seasonNumber = model.SeasonCount;
            //        var seasonInfo = Task.Run(() => apiLib.SeasonEpisodesAsync(model.IMDbMovieId, seasonNumber)).Result;
            //        var season = new Seasons()
            //        {
            //            Name = "Season" + model.SeasonCount.ToString(),
            //            Media = model,
            //            Year = Convert.ToInt32(seasonInfo.Year)
            //        };
            //        context.SeasonsTable.Add(season);
            //        model.SeasonsList.Add(context.SeasonsTable.FirstOrDefault(x => x.Id == season.Id));
            //        foreach (var z in seasonInfo.Episodes)
            //        {
            //            ++season.EpisodeCount;
            //            var episode = new Episode()
            //            {
            //                Name = "Episode" + season.EpisodeCount.ToString(),
            //                Seasons = season,
            //                Plot = z.Plot,
            //                Image = z.Image,
            //                Year = z.Year,
            //                RatingValue = z.RatingValue
            //            };
            //            context.EpisodeTable.Add(episode);
            //            season.EpisodesList.Add(context.EpisodeTable.FirstOrDefault(x => x.Id == episode.Id));
            //        }
            //    }

            //    context.MediaTable.AddOrUpdate(
            //        a => new { a.IMDbMovieId }, model);
            //}
            //context.SaveChanges();

            //upload

            //var apiLib = new ApiLib("5zfN3eE59H");
            //var dataApi = Task.Run(() => apiLib.Top250MoviesAsync()).Result;
            //var searchResults = dataApi.Items;

            //for (var i = 130; i < 150; ++i)
            //{
            //    var id = i;
            //    var movieData = Task.Run(() => apiLib.TitleAsync(searchResults[id].Id)).Result;

            //    var model = context.MediaTable.FirstOrDefault(x => x.Name == movieData.Title);
            //    var trailer = Task.Run(() => apiLib.TrailerAsync(model.IMDbMovieId)).Result;
            //    model.LinkEmbed = trailer.LinkEmbed;

            //    context.MediaTable.AddOrUpdate(
            //        a => new { a.IMDbMovieId }, model);
            //}
            //context.SaveChanges();
        }
    }
}
