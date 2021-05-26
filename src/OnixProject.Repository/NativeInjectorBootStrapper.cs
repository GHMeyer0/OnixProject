using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnixProject.Domain.Repositories;
using OnixProject.Repository.Contexts;
using OnixProject.Repository.Repositories;
using System.Reflection;

namespace OnixProject.Repository
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<OnixContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("database"), options =>
                {
                    options.MigrationsAssembly(typeof(NativeInjectorBootStrapper).Assembly.ToString());
                });
            });




            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}