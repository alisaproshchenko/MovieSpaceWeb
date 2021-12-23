namespace MoviesService.Dto
{
    public class SeasonsDto
    {
        public string SeriesId { get; set; }
        public string IMDbMovieId { get; set; }
        public int Year { get; set; }
        public double? RatingIMDb { get; set; }
        public double? UserIMDb { get; set; }
    }
}