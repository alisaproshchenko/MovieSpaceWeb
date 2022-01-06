using MoviesService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMDbApiLib;
using MoviesService.IMDbApi;
using MoviesService.Models;

namespace MoviesService.Data
{
    public class SedTop250IMDb
    {
        public SedTop250IMDb()
        {
            
        }

        public async Task<List<Media>> GetSearchAsynTask()
        {
            var apiLib = new ApiLib("k_d99sty8t");
            var convertor = new ConvertorApiData();
            var dataApi = await apiLib.Top250MoviesAsync();

            var searchResults = dataApi.Items;
            
            var modeList = new List<Media>();

            for (var i = 0; i < 10; i++)
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
                    Types = new Types {Name = movieData.Type},
                    RatingIMDb = convertor.StrToDouble(movieData.IMDbRating),
                    CountryCollection = convertor.Countries(movieData.Countries),
                    GenresCollection = convertor.Genres(movieData.GenreList)
                };

                modeList.Add(model);
            }

            return modeList;
        }
    }
}
