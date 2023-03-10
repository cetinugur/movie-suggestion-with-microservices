using System.Net;
using Services.Shared.Dictionaries;
using Services.Shared.Models;
using Services.Movie.Repositories.Interfaces;

namespace Services.Movie.Api.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _MovieRepository;

        public MovieService(IMovieRepository MovieRepository)
        {
            _MovieRepository = MovieRepository;
        }

        public ApiResult Get(int id)
        {
            var Movie = _MovieRepository.FirstOrDefault(x => x.Id == id);
            if (Movie == null)
                return new ApiResult(HttpStatusCode.NotFound, MessageDictionary.MovieNotFound);

            return new ApiResult(HttpStatusCode.OK, Movie);
        }


        public ApiResult Add(Model.Movie Movie)
        {
            var result = _MovieRepository.Add(Movie).SaveChanges();
            if (!result)
                return new ApiResult(HttpStatusCode.BadRequest, MessageDictionary.MovieNotAdded);

            return new ApiResult(HttpStatusCode.OK, MessageDictionary.MovieAdded);
        }

        public ApiResult List(int offset, int limit)
        {
            var list = _MovieRepository.GetAllAsNoTracking(offset, limit);
            if (!list.Any())
                return new ApiResult(HttpStatusCode.NotFound, MessageDictionary.MovieNotFound);

            var totalCount = _MovieRepository.Count();
            return new ApiResult(HttpStatusCode.OK, list, string.Empty, totalCount);
        }

        public ApiResult Count()
        {
            var totalCount = _MovieRepository.Count();
            return new ApiResult(HttpStatusCode.OK, totalCount);
        }
    }
}
