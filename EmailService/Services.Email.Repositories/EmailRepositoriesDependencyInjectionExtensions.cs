using Microsoft.Extensions.DependencyInjection;
using Services.Email.Repositories.Interfaces;
using Services.Email.Repositories.Repositories;

namespace Services.Email.Repositories
{
    public static class EmailRepositoriesDependencyInjectionExtensions
    {
        public static IServiceCollection AddEmailDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmailRepository, EmailRepository>();
            return services;
        }
    }
}
