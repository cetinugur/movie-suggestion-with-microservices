using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Shared.Authentication.Helper;

namespace Services.Movie.Client.Base
{
    public static class MovieApiClientDependencyInjectionExtensions
    {
        public static IServiceCollection AddMovieApiClient(this IServiceCollection services, Action<MovieServiceClientOptions> options)
        {
            services.AddOptions<MovieServiceClientOptions>().Configure(options);
            services.AddTransient<MovieClient>();
            services.AddHttpContextAccessor();
            services.TryAddTransient<HttpContextHelper>();
            return services;
        }
    }
}
