using MoviesService.Models;

namespace MoviesService.Dto
{
    public class EpisodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string RatingValue { get; set; }
        public int? SeasonsId { get; set; }
        public Seasons Seasons { get; set; }
    }
}
