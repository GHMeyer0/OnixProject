using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace OnixProject.Domain
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(NativeInjectorBootStrapper));

            return services;
        }
    }
}