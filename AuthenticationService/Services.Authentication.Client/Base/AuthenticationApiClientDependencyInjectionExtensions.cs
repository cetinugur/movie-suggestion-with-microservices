using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Services.Shared.Authentication.Helper;

namespace Services.Authentication.Client.Base
{
    public static class AuthenticationApiClientDependencyInjectionExtensions
    {
        public static IServiceCollection AddAuthenticationApiClient(this IServiceCollection services, Action<AuthenticationClientOptions> options)
        {
            services.AddOptions<AuthenticationClientOptions>().Configure(options);
            services.AddTransient<AuthenticationClient>();
            services.AddHttpContextAccessor();
            services.TryAddTransient<HttpContextHelper>();
            return services;
        }
    }
}
