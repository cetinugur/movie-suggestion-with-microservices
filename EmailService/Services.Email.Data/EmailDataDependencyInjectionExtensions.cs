using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.Email.Data
{
    public static class EmailDataDependencyInjectionExtensions
    {
        public static IServiceCollection AddEmailDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmailDbContext>(options =>
            // TODO : not hardcoded
                options.UseNpgsql(configuration.GetConnectionString("EmailDb")));
            return services;
        }
    }
}
