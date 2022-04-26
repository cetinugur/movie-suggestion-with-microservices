namespace Services.Movie.Model
{
    public class MovieNote : EntityBase
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
    }
}
