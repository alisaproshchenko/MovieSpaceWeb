using System.Collections.Generic;
using MoviesService.Context;
using MoviesService.Models;

namespace MoviesService.Search
{
    public class SearchInDataBase
    {
        private readonly MediaDbContext _context;
        public SearchInDataBase()
        {
            _context = new MediaDbContext();
        }

        public List<Media> SearchByName(string name)
        {
            var mediaList = new List<Media>();
            
            var listSearch = _context.MediaTable
                .Include("Types")
                .Include("GenresCollection")
                .Include("CountryCollection")
                .Include("SeasonsList");

            foreach (var model in listSearch)
            {
                if (model.Name.ToLower().Contains(name.ToLower()))
                    mediaList.Add(model);
            }

            return mediaList;
        }

    }
}
