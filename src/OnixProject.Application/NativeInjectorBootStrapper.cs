using Microsoft.Extensions.DependencyInjection;
using OnixProject.Application.Services;
using OnixProject.Application.Services.Interfaces;

namespace OnixProject.Application
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}