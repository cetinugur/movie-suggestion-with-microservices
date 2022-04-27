using RestSharp;
using System.Net;

namespace Services.Movie.Feeder.TheMovieDbClient
{
    public class GetMovieClient
    {
        protected RestClient _client;
        private const int DefaultTimeout = 60 * 60;
        protected string end_point = string.Empty;
        protected string api_url = string.Empty;
        protected string api_key = string.Empty;
        protected string language = string.Empty;
        public GetMovieClient(string pApiUrl, string pEnd_point, string pApi_key, string pLanguage)
        {
            end_point = pEnd_point;
            api_url = pApiUrl;
            api_key = pApi_key;
            language = pLanguage;

            var _apiUrl = api_url;
            if (_apiUrl.LastIndexOf("/", StringComparison.Ordinal) == 0)
                _apiUrl += "/";

            _client = new RestClient(_apiUrl + end_point);

        }

        public string? GetMovieList(int page)
        {
            string? result = null;
            var request = CreateRequest(page, Method.Get);

            var response = Task.Run(async () => await _client.ExecuteAsync<string>(request)).Result;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    result = response.Content;
                    break;
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.InternalServerError:
                default:
                    throw new Exception(PopulateErrorMessage(_client, request, response, "Film listesi alınırken hata oluştu."));
            }
            return result;
        }

        private RestRequest CreateRequest(int page, Method method, int timeout = DefaultTimeout)
        {
            var request = new RestRequest
            {
                Method = method,
                Timeout = timeout,
                CompletionOption = HttpCompletionOption.ResponseContentRead
            };
            request.AddUrlSegment(nameof(page), page);
            request.AddParameter(nameof(api_key), api_key);
            request.AddParameter(nameof(language), language);
            return request;
        }

        protected string PopulateErrorMessage(RestClient client, RestRequest request, RestResponse response, string messagePrefix)
        {
            string message = $"Message : {response.ErrorException?.Message}";
            if (response.ErrorException != null && response.ErrorException.InnerException != null)
            {
                message += $"Message : {response.ErrorException.InnerException.Message}";
            }
            return $"{messagePrefix} : {client.BuildUri(request).AbsoluteUri} - {message} - Content : {response.Content} -  Status : {response.StatusCode}  - {response.ResponseStatus} - {response.StatusDescription}";

        }
    }
}