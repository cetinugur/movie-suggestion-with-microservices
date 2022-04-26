using Services.Movie.Model;
using Services.Shared.Models;

namespace Services.Movie.Client.Interfaces;

public interface IMovieClient
{
    ServiceResult<Model.Movie> Get(Guid movieId);
    ServiceResult Add(Model.Movie movie);
    ServiceResult Update(Model.Movie movie);
    ServiceResult Delete(Guid movieId);
    ServiceResult<List<Model.Movie>> List(int offset = 0, int limit = 1000);
    ServiceResult Count();
}