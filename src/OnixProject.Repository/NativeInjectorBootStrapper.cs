using EFCoreSecondLevelCacheInterceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnixProject.Domain.Repositories;
using OnixProject.Repository.Contexts;
using OnixProject.Repository.Repositories;

namespace OnixProject.Repository
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {

            const string cacheProvider = "redis";
            services.AddEFSecondLevelCache(options =>
            {
                options.UseEasyCachingCoreProvider(cacheProvider, isHybridCache: false);
                options.DisableLogging();
                options.UseCacheKeyPrefix("EF_")
                 .DisableLogging(true).UseCacheKeyPrefix("EF_");
            });
            services.AddEasyCaching(option =>
            {
                option.UseRedis(configuration, cacheProvider, "ConnectionStrings:redis");
            });

            services.AddDbContext<OnixContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("database"), options =>
                {
                    options.MigrationsAssembly(typeof(NativeInjectorBootStrapper).Assembly.ToString());
                });
                options.AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>());
        });
            services.AddScoped<IUnitOfWork, OnixContext>();


            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}