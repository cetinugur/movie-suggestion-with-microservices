using Services.Shared.Client;
using Microsoft.Extensions.Options;
using RestSharp;
using Services.Shared.Authentication.Helper;
using Services.Shared.Models;
using Services.Movie.Client.Interfaces;
using Services.Movie.Client.Base;
using Services.Movie.Model;

namespace Services.Movie.Client
{
    public class MovieClient : ClientBase, IMovieClient
    {
        public MovieClient(HttpContextHelper httpContext, IOptions<MovieServiceClientOptions> options)
              : base(httpContext.CurrentUser.AccessToken, options.Value)
        {
        }

        public ServiceResult Add(Model.Movie model)
        {
            var request = CreateRequest<ServiceResult>(MovieApiConstants.MovieAdd, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult<Model.Movie> Get(Guid movieId)
        {
            var request = CreateRequest<ServiceResult<Model.Movie>>(MovieApiConstants.MovieGet, null, Method.Get,
                new UrlSegmentParam() { Name = "id", Value = movieId });
            return HandleResponse(request);
        }
        public ServiceResult Update(Model.Movie model)
        {
            var request = CreateRequest<ServiceResult>(MovieApiConstants.MovieUpdate, model, Method.Post);
            return HandleResponse(request);
        }

        public ServiceResult Delete(Guid movieId)
        {
            var request = CreateRequest<ServiceResult>(MovieApiConstants.MovieDelete, null, Method.Delete,
                new UrlSegmentParam() { Name = "id", Value = movieId });
            return HandleResponse(request);
        }

        public ServiceResult<List<Model.Movie>> List(int offset = 0, int limit = 1000)
        {
            var request = CreateRequest<ServiceResult<List<Model.Movie>>>(MovieApiConstants.MovieList, null, Method.Get,
                new UrlSegmentParam() { Name = "offset", Value = offset },
                new UrlSegmentParam() { Name = "limit", Value = limit });
            return HandleResponse(request);
        }



        public ServiceResult Count()
        {
            var request = CreateRequest<ServiceResult>(MovieApiConstants.MovieCount, null, Method.Get);
            return HandleResponse(request);
        }
    }
}
