using Microsoft.EntityFrameworkCore;
using OrderPackagingService.Infra.Data;

namespace OrderPackagingService.Api.Extensions.Services
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
