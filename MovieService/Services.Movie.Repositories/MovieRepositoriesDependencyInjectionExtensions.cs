using Microsoft.Extensions.DependencyInjection;
using Services.Movie.Repositories.Interfaces;
using Services.Movie.Repositories.Repositories;

namespace Services.Movie.Repositories
{
    public static class MovieRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddMovieDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}
