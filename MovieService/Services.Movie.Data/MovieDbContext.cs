using Microsoft.EntityFrameworkCore;
using Services.Movie.Model;

namespace Services.Movie.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        public DbSet<MovieModel> Movies { get; set; }
    }
}
