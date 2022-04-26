using System.ComponentModel.DataAnnotations.Schema;

namespace Services.Movie.Model
{
    public abstract class MovieSubModelBase : EntityBase
    {
        public Guid MovieId { get; set; }
        public int UserId { get; set; }
    }
}
