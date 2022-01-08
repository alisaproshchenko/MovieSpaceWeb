using System.Collections.Generic;
using System.Linq;
using IMDbApiLib;
using MoviesService.Dto;
using System.Threading.Tasks;
using MoviesService.Models;

namespace MoviesService.IMDbApi
{
    public class SearchMovieInIMDbApi
    {
        private static ApiLib _apiLib;
        private  ConvertorApiData _convertor = new ConvertorApiData();

        public SearchMovieInIMDbApi()
        {
            _apiLib = new ApiLib("k_sq5f8w2a");
        }

        public SearchMovieInIMDbApi(string key)
        {
            _apiLib = new ApiLib(key);
        }

        public Media SearchMedia(string name)
        {
            var dataApi = Task.Run(() =>  _apiLib.SearchAsync(name)).Result;

            var searchResults = dataApi.Results;

            var movieData = Task.Run(() =>  _apiLib.TitleAsync(searchResults[0].Id)).Result;

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
                GenresCollection = _convertor.Genres(movieData.GenreList)
            };

            return model;
        }
    }
}
