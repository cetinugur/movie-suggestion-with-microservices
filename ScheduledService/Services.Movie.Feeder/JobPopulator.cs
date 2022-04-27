using Quartz;
using Quartz.Impl;
using Services.Movie.Api.Services;
using Services.Movie.Feeder.TheMovieDbClient;

namespace Services.Movie.Feeder
{
    public  class JobPopulator
    {
        private readonly GetMovieClient _client;
        private readonly MovieService _movieService;

        public JobPopulator(GetMovieClient client, MovieService movieService)
        {
            _client = client;
            _movieService = movieService;
        }
        public async void Persist(string control_period)
        {
            IJobDetail? jobdetail = null;
            ITrigger? trigger = null;

            JobKey jobKey = JobKey.Create("MovieFeeder");

            jobdetail = JobBuilder.Create().
               WithIdentity(jobKey)
               .OfType(typeof(Feeder))
               .Build();

            jobdetail.JobDataMap[nameof(GetMovieClient)] = _client;
            jobdetail.JobDataMap[nameof(MovieService)] = _movieService;

            trigger = TriggerBuilder.Create()

            .WithIdentity("MovieFeederCron")
            .StartNow()
            .WithSimpleSchedule(builder => builder.RepeatForever()).WithCronSchedule(control_period)

            .Build();
            var _scheduler = await new StdSchedulerFactory().GetScheduler();
            await _scheduler.Start();
            await _scheduler.ScheduleJob(jobdetail, trigger);


        }
    }
}
