using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Context;
using MoviesService.IMDbApi;
using MoviesService.Models;

namespace MoviesService.Search
{
    public class SearchInDataBase
    {
        private readonly MediaDbContext _context;
        private readonly ConvertorApiData _convertor;
        private static DbQuery<Media> _listMedia;
        public SearchInDataBase()
        {
            _context = new MediaDbContext();
            _convertor = new ConvertorApiData();
            _listMedia = _context.MediaTable
                .Include("Types")
                .Include("GenresCollection")
                .Include("CountryCollection")
                .Include("SeasonsList");
        }

        public List<Media> MediaList()
        {
            var mediaList = new List<Media>();

            foreach (var model in _listMedia)
            {
                mediaList.Add(model);
            }

            mediaList.OrderByDescending(m => m.RatingIMDb);
            return mediaList;
        }

        public List<Genres> GenreList()
        {
            var genresList = new List<Genres>();

            var genres = _context.GenresTable;

            genresList.Add(new Genres { Id = 0, Name = "All" });

            foreach (var genre in genres)
            {
                genresList.Add(genre);
            }

            return genresList;
        }

        public List<string> YearList()
        {
            var yearList = new List<string>();

            foreach (var model in _listMedia)
            {
                if (model.Year.ToString() != null && model.Year != 0)
                    yearList.Add(model.Year.ToString());
            }

            yearList = yearList.Distinct().ToList();
            return yearList;
        }

        public List<Media> SearchByName(string name)
        {
            var mediaList = new List<Media>();

            foreach (var model in _listMedia)
            {
                if (model.Name.ToLower().Contains(name.ToLower()))
                    mediaList.Add(model);
            }

            mediaList.OrderByDescending(m => m.RatingIMDb);
            return mediaList;
        }

        public List<Media> SearchByGenre(string genre, List<Media> listSearch)
        {
            var mediaList = new List<Media>();

            foreach (var model in listSearch)
            {
                foreach (var genres in model.GenresCollection)
                {
                    if (genres.Id == _convertor.StrToInt(genre))
                        mediaList.Add(model);
                }
            }

            mediaList.OrderByDescending(m => m.RatingIMDb);
            return mediaList;
        }

        public List<Media> SearchByYear(string year, List<Media> listSearch)
        {
            var mediaList = new List<Media>();

            foreach (var model in listSearch)
            {
                if (model.Year == _convertor.StrToInt(year))
                        mediaList.Add(model);
            }

            mediaList.OrderByDescending(m => m.RatingIMDb);
            return mediaList;
        }
    }
}
