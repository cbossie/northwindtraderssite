using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("NorthwindPostgreDatabase")));

            services.AddScoped<INorthwindDbContext>(provider => provider.GetService<NorthwindDbContext>());

            return services;
        }
    }
}
