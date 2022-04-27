using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Movie.Model
{
    public class Movie : EntityBase
    {
        public string Name { get; set; }
        public virtual IEnumerable<MovieNote> Notes { get; set; }
        public virtual IEnumerable<MovieRank> Ranks { get; set; }

        [NotMapped]
        public decimal? Rank
        {
            get {

                if (Ranks is null) return null;
                return Ranks.Select(x => (decimal?)x.Rank).Average(); 
            }
        }
    }
}
