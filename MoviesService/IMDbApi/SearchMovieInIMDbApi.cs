using IMDbApiLib;
using MoviesService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDbApiLib.Models;
using MoviesService.Models;

namespace MoviesService.IMDbApi
{
    public class SearchMovieInIMDbApi
    {
        private static ApiLib _apiLib;
        private  ConvertorApiData _convertor = new ConvertorApiData();

        public SearchMovieInIMDbApi()
        {
            _apiLib = new ApiLib("k_d99sty8t");
        }

        public SearchMovieInIMDbApi(string key)
        {
            _apiLib = new ApiLib(key);
        }

        public async Task<MediaDto> SearchAsynTask(string name)
        {
            var dataApi = await _apiLib.SearchAsync(name);

            var searchResults = dataApi.Results;

            var movieData = await _apiLib.TitleAsync(searchResults[0].Id);

            var model = new MediaDto
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
