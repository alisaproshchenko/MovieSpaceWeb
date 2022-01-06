using MoviesService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IMDbApiLib;
using MoviesService.Context;
using MoviesService.IMDbApi;
using MoviesService.Models;
using MoviesService.Repositories.Repository;

namespace MoviesService.Data
{
    public class SeedTop250IMDb
    {
        public static List<Media> TestList = GetSearchAsynTask().Result.ToList();
        private static MediaDbContext _context = new MediaDbContext();
        public SeedTop250IMDb()
        {
            //List<Media> medias = GetSearchAsynTask().Result.ToList();
            //TestList = medias;
        }

        public static async Task<List<Media>> GetSearchAsynTask()
        {
            var apiLib = new ApiLib("k_ag12ki7h");
            var convertor = new ConvertorApiData();
            var dataApi = await apiLib.Top250MoviesAsync();

            var searchResults = dataApi.Items;
            
            var modeList = new List<Media>();

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
                //GenresCollection = convertor.Genres(movieData.GenreList),
                //Types = new Types { Name = movieData.Type }
                if (_context.TypesTable.Any(x => x.Name != movieData.Type))
                {
                    model.Types = new Types {Name = movieData.Type};
                }
                else
                {
                    var typeId = _context.TypesTable.FirstOrDefault(x => x.Name == movieData.Type).Id;
                    model.Types = _context.TypesTable.FirstOrDefault(x => x.Id == typeId);
                }

                var listCountries = convertor.Countries(movieData.Countries);
                    foreach (var country in listCountries)
                    {
                        if (_context.CountriesTable.Any(x => x.Name != country.Name))
                        {
                            model.CountryCollection.Add(country);
                        }
                        else
                        {
                            var countryId = _context.CountriesTable.FirstOrDefault(x => x.Name == country.Name).Id;
                            model.CountryCollection.Add(_context.CountriesTable.FirstOrDefault(x => x.Id == countryId));
                        }
                    }


                var listGenres = convertor.Genres(movieData.GenreList);
                    foreach (var genre in listGenres)
                    {
                    if (_context.CountriesTable.Any(x => x.Name != genre.Name))
                    {
                        model.GenresCollection.Add(genre);
                    }
                    else
                    {
                        var genreId = _context.GenresTable.FirstOrDefault(x => x.Name == genre.Name).Id;
                        model.GenresCollection.Add(_context.GenresTable.FirstOrDefault(x => x.Id == genreId));
                    }
}
                modeList.Add(model);
            }

            return modeList;
        }
    }
}
