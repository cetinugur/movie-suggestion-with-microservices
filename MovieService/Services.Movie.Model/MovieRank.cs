namespace Services.Movie.Model
{
    public class MovieRank : EntityBase
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public short Rank { get; set; }
    }
}
