using Microsoft.Extensions.DependencyInjection;
using OnixProject.Domain;
using OnixProject.Repository;

namespace OnixProject.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.RegisterDomainServices();
            services.RegisterRepositoryServices();
            services.RegisterApplicationServices();
            return services;
        }
    }
}