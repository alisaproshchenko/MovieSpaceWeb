using System.Linq;
using IMDbApiLib;
using MoviesService.Context;
using MoviesService.IMDbApi;
using MoviesService.Models;

namespace MoviesService.Data
{
    public class SeedTop250IMDb
    {
        public static async void GetSearchAsynTask(MediaDbContext context)
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
                //CountryCollection = convertor.Countries(movieData.Countries),
                //GenresCollection = convertor.Genres(movieData.GenreList)
                //Types = new Types { Name = movieData.Type },
                if (context.TypesTable.Any(x => x.Name != movieData.Type))
                {
                    context.TypesTable.Add(new Types {Name = movieData.Type});
                }
                model.Types = context.TypesTable.FirstOrDefault(x => x.Name == movieData.Type);

                var genresList = convertor.Genres(movieData.GenreList);
                foreach (var genre in genresList)
                {
                    if (context.GenresTable.Any(x => x.Name == genre.Name))
                    {
                        context.GenresTable.Add(new Genres { Name = genre.Name });
                    }
                    model.GenresCollection.Add(context.GenresTable.FirstOrDefault(x => x.Name == genre.Name));
                }

                var countriesList = convertor.Countries(movieData.Countries);
                foreach (var country in countriesList)
                {
                    if (context.CountriesTable.Any(x => x.Name == country.Name))
                    {
                        context.CountriesTable.Add(new Country { Name = country.Name });
                    }
                    model.CountryCollection.Add(context.CountriesTable.FirstOrDefault(x => x.Name == country.Name));
                }

                context.MediaTable.Add(model);
                await context.SaveChangesAsync();
            }
        }
    }
}