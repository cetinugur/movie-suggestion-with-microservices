using Services.Shared.Data.Repository;
using Services.Movie.Data;
using Services.Movie.Model;
using Services.Movie.Repositories.Interfaces;

namespace Services.Movie.Repositories.Repositories
{
    public class MovieRepository : Repository<Model.Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context) : base(context)
        {

        }
    }
}
