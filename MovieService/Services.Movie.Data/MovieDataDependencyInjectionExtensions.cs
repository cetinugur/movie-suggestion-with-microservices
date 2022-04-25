using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Shared.Dictionaries;

namespace Services.Movie.Data
{
    public static class MovieDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddMovieDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(DbDictionary.DbName)));
            return services;
        }
    }
}
