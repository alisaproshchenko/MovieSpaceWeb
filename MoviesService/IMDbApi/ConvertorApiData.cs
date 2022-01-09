using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IMDbApiLib.Models;
using MoviesService.Models;

namespace MoviesService.IMDbApi
{
    public class ConvertorApiData
    {
        public ConvertorApiData()
        {
        }

        public string Actors(List<ActorShort> actors)
        {
            var actorsStr = "";
            
            foreach (var actor in actors)
            {
                actorsStr += actor.Name + ", ";
            }

            return actorsStr;
        }

        public List<Country> Countries(string countriesStr)
        {
            var countriesList = new List<Country>();
            var countries = countriesStr.Split(',');

            foreach (var country in countries)
            {
                var countryForList = new Country
                {
                    Name = country
                };
                countriesList.Add(countryForList);
            }

            return countriesList;
        }

        public List<Genres> Genres(List<KeyValueItem> GenreList)
        {
            var genresList = new List<Genres>();

            foreach (var item in GenreList)
            {
                var genreForList = new Genres
                {
                    Name = item.Value
                };
                genresList.Add(genreForList);
            }

            return genresList;
        }

        public int StrToInt(string str)
        {
            int value;

            if (!int.TryParse(str, out value))
                return 0;

            return value;
        }

        public double StrToDouble(string str)
        {
            double value;

            if (!double.TryParse(str, out value))
                return 0;

            return value;
        }
    }
}
