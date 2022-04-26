using Services.Movie.Model;
using Services.Shared.Models;

namespace Services.Movie.Client.Interfaces;

public interface IMovieClient
{
    ServiceResult<MovieModel> Get(Guid movieId);
    ServiceResult Add(MovieModel movie);
    ServiceResult Update(MovieModel movie);
    ServiceResult Delete(Guid movieId);
    ServiceResult<List<MovieModel>> List(int offset = 0, int limit = 1000);
    ServiceResult Count();
}