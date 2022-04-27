// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Movie.Api.Services;
using Services.Movie.Data;
using Services.Movie.Feeder;
using Services.Movie.Feeder.Models;
using Services.Movie.Feeder.TheMovieDbClient;
using Services.Movie.Repositories;

var services = new ServiceCollection();

string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var appsettingsfile = string.IsNullOrEmpty(environment) ? "appsettings.json" : $"appsettings.{environment}.json";

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile(appsettingsfile)
    .AddEnvironmentVariables()
    .Build();


services.AddSingleton<JobPopulator>();

var clientInstance = new GetMovieClient(config.GetSection("ProjectSettings:api_url").Value,
                            config.GetSection("ProjectSettings:end_point").Value,
                            config.GetSection("ProjectSettings:api_key").Value,
                            config.GetSection("ProjectSettings:language").Value);
services.AddSingleton<GetMovieClient>(clientInstance);

services.AddMovieDb(config);
services.AddMovieDataRepositories();
services.AddScoped<MovieService>();

await using (var scope = services.BuildServiceProvider().CreateAsyncScope())
{
    scope.ServiceProvider.GetRequiredService<JobPopulator>().Persist(config.GetSection("ProjectSettings:control_period").Value);
}

Console.ReadLine();