using Microsoft.Extensions.DependencyInjection;

namespace OnixProject.Repository
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            // TODO: Adicionar Entity Framwork
            return services;
        }
    }
}