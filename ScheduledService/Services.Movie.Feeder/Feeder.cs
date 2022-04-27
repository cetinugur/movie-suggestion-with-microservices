using Newtonsoft.Json;
using Quartz;
using Services.Movie.Api.Services;
using Services.Movie.Feeder.Models;
using Services.Movie.Feeder.TheMovieDbClient;

namespace Services.Movie.Feeder
{
    [DisallowConcurrentExecution]
    public class Feeder : IJob
    {
        private MovieService _movieService;
        private GetMovieClient _client;

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("Trigged");
                _movieService = (MovieService)context.JobDetail.JobDataMap[nameof(MovieService)];
                _client = (GetMovieClient)context.JobDetail.JobDataMap[nameof(GetMovieClient)];

                var serviceResult = JsonConvert.DeserializeObject<MovieFeed>(_client.GetMovieList(1));

                foreach (var item in serviceResult.Movies)
                {
                    _movieService.Add(new Model.Movie
                    {
                        CreateDate = DateTime.Now,
                        Name = item.OriginalTitle,
                    });
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

            return Task.CompletedTask;
        }
    }
}
