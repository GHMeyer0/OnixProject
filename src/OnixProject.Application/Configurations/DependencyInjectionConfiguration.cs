using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnixProject.Domain;
using OnixProject.Repository;

namespace OnixProject.Application.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDomainServices();
            services.RegisterRepositoryServices(configuration);
            services.RegisterApplicationServices();
            services.AddSignalRCore();
            return services;
        }


    }
}