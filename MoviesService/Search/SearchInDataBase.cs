using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
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

        public List<Media> MediaList() => _listMedia.OrderByDescending(m => m.RatingIMDb).ToList();
        public List<UsersToMedia> UsersToMedia() => _context.UsersToMediaTable.ToList();
       
        public List<Media> MediaTop250List() => _listMedia.OrderByDescending(m => m.RatingIMDb).Take(250).ToList();

        public List<Media> MostLikeMovies() =>_listMedia
            .Where(m=>m.AmountOfLikes != null && m.AmountOfLikes != 0)
            .OrderByDescending(m => m.AmountOfLikes)
            .ToList();

        public List<Media> MostWatched()
        {
            var watchedDictionary = new Dictionary<int, int>();
            var mostW = new List<Media>();
            
            foreach (var val in _context.UsersToMediaTable)
            {
                if (!watchedDictionary.ContainsKey(val.MediaId))
                    watchedDictionary.Add(val.MediaId, 1);
                else
                    watchedDictionary[val.MediaId]++;
            }

            foreach (var watched in watchedDictionary)
            {
                mostW.Add(_listMedia.First(m => m.Id == watched.Key));
            }

            return mostW;
        }

        public List<Media> FiltersConditions(string[] selectedGenres, string country, string year, string type)
        {
            var model = MediaList();

            if (country != null && _convertor.StrToInt(country) != 0)
                model = SearchByCountry(country, model);

            if (selectedGenres != null && selectedGenres.Length != 0)
                foreach (var g in selectedGenres)
                {
                    model = SearchByGenre(g, model);
                }

            if ((year != null || _convertor.StrToInt(year) != 0) && year != "All")
                model = SearchByYear(year, model);

            if ((type != null || _convertor.StrToInt(type) != 0) && type != "All")
                model = SearchByType(type, model);

            return model;
        }

        public List<Genres> GenreList()
        {
            var genresList = new List<Genres>();

            foreach (var genre in _context.GenresTable)
            {
                genresList.Add(genre);
            }

            return genresList;
        }

        public LinkedList<Country> CountryList()
        {
            var genresList = new LinkedList<Country>();
            genresList.AddFirst(new Country { Id = 0, Name = "All" });

            foreach (var country in _context.CountriesTable)
            {
                genresList.AddLast(country);
            }

            return genresList;
        }

        public List<string> TypesList()
        {
            var typesList = new List<string>();
            typesList.Add("All");

            foreach (var type in _context.TypesTable)
            {
                typesList.Add(type.Name);
            }

            return typesList;
        }

        public List<string> YearList()
        {
            var yearList = new List<string>();
            yearList.Add("All");

            foreach (var model in _listMedia)
            {
                if (model.Year.ToString() != null && model.Year != 0)
                    yearList.Add(model.Year.ToString());
            }

            yearList = yearList.Distinct().OrderByDescending(x => x).ToList();
            return yearList;
        }

        public List<Media> SearchByName(string name)
        {
            var mediaList = _listMedia
                .Where(m => m.Name.ToLower().Contains(name.ToLower()))
                .OrderByDescending(m => m.RatingIMDb)
                .ToList();

            return mediaList;
        }

        public List<Media> SearchByGenre(string genre, List<Media> listSearch)
        {
            listSearch = listSearch
                .Where(m => m.GenresCollection.Any(g =>g.Id == _convertor.StrToInt(genre)))
                .OrderByDescending(r => r.RatingIMDb)
                .ToList();

            return listSearch;
        }

        public List<Media> SearchByCountry(string country, List<Media> listSearch)
        {
            listSearch = listSearch
                .Where(m => m.CountryCollection.Any(g => g.Id == _convertor.StrToInt(country)))
                .OrderByDescending(r => r.RatingIMDb)
                .ToList();

            return listSearch;
        }

        public List<Media> SearchByYear(string year, List<Media> listSearch)
        {
            listSearch = listSearch
                .Where(m => m.Year == _convertor.StrToInt(year))
                .OrderByDescending(r => r.RatingIMDb)
                .ToList();

            return listSearch;
        }

        public List<Media> SearchByType(string type, List<Media> listSearch)
        {
            listSearch = listSearch
                .Where(m => m.Types.Name == type)
                .OrderByDescending(m=>m.RatingIMDb)
                .ToList();

            return listSearch;
        }

        public bool CheckByName(string name) => _listMedia.Any(m => m.Name.ToLower() == name.ToLower());
    }
}
