using System.Collections.Generic;
using IMDbApiLib;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MoviesService.Models;

namespace MoviesService.IMDbApi
{
    public class SearchMovieInIMDbApi
    {
        private static ApiLib _apiLib;
        private ConvertorApiData _convertor;

        public SearchMovieInIMDbApi()
        {
            _apiLib = new ApiLib("k_wxbph9cx");
            _convertor = new ConvertorApiData();
        }

        public SearchMovieInIMDbApi(string key)
        {
            _apiLib = new ApiLib(key);
            _convertor = new ConvertorApiData();
        }

        public List<Media> SearchMedia(string name)
        {
            var dataApi = Task.Run(() =>  _apiLib.SearchAsync(name)).Result;

            var searchResults = dataApi.Results;

            var listMedia = new List<Media>();

            if (searchResults.IsNullOrEmpty())
                return null;

            foreach (var result in searchResults)
            {
                var movieData = Task.Run(() => _apiLib.TitleAsync(result.Id)).Result;
                var model = new Media
                {
                    IMDbMovieId = movieData.Id,
                    Name = movieData.Title,
                    Poster = movieData.Image,
                    Year = _convertor.StrToInt(movieData.Year),
                    Cast = _convertor.Actors(movieData.ActorList),
                    Plot = movieData.Plot,
                    Budget = movieData.BoxOffice.Budget,
                    BoxOffice = movieData.BoxOffice.CumulativeWorldwideGross,
                    Types = new Types {Name = movieData.Type},
                    RatingIMDb = _convertor.StrToDouble(movieData.IMDbRating),
                    CountryCollection = _convertor.Countries(movieData.Countries),
                    GenresCollection = _convertor.Genres(movieData.GenreList)
                };
                listMedia.Add(model);
            }

            return listMedia;
        }

        public Media SearchTitle(string id)
        {
            var movieData = Task.Run(() => _apiLib.TitleAsync(id)).Result;
            var trailerUrl = Task.Run(() => _apiLib.TrailerAsync(id)).Result;
            var model = new Media
            {
                IMDbMovieId = movieData.Id,
                Name = movieData.Title,
                Poster = movieData.Image,
                Year = _convertor.StrToInt(movieData.Year),
                Cast = _convertor.Actors(movieData.ActorList),
                Plot = movieData.Plot,
                Budget = movieData.BoxOffice.Budget,
                BoxOffice = movieData.BoxOffice.CumulativeWorldwideGross,
                Types = new Types { Name = movieData.Type },
                RatingIMDb = _convertor.StrToDouble(movieData.IMDbRating),
                CountryCollection = _convertor.Countries(movieData.Countries),
                GenresCollection = _convertor.Genres(movieData.GenreList),
                LinkEmbed = trailerUrl.LinkEmbed
            };
            return model;
        }
    }
}
