using System.Collections.Generic;
using MoviesService.Models;

namespace Web.ViewModels
{
    public class MediaViewModel
    {
        public int Id { get; set; }
        public string IMDbMovieId { get; set; }
        public string Name { get; set; }
        public string Poster { get; set; }
        public int Year { get; set; }
        public string Cast { get; set; }
        public string Plot { get; set; }
        public int? BudgetAndBoxOffice { get; set; }
        public double? RatingIMDb { get; set; }
        public double? SiteUsersRatings { get; set; }
        public int TypesId { get; set; }
        public ICollection<Genres> GenresCollection { get; set; }
    }
}