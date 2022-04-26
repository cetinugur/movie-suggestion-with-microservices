using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Shared.Dictionaries;

namespace Services.Authentication.Data
{
    public static class AuthenticationDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddAuthenticationDb(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString(DbDictionary.AuthenticationDb), opt =>
                {
                    opt.EnableRetryOnFailure(5);
                })); 

            return services;
        }
    }
}
