using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Context;
using MoviesService.Dto;
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
        
        public LinkedList<Genres> GenreList()
        {
            var genresList = new LinkedList<Genres>(); 
            genresList.AddFirst(new Genres { Id = 0, Name = "All" });

            foreach (var genre in _context.GenresTable)
            {
                genresList.AddLast(genre);
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
    }
}
