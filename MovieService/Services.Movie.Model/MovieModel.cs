using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Movie.Model
{
    public class MovieModel : EntityBase
    {
        public string Name { get; set; }
        public List<MovieNoteModel> Notes { get; set; }
        public List<MovieRankModel> Ranks { get; set; }

        [NotMapped]
        public decimal Rank
        {
            get { return Ranks.Select(x => (decimal)x.Rank).Average(); }
        }
    }
}
