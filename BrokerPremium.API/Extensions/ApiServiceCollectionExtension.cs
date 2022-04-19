using BrokerPremium.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Micrososft.Extensions.DependecyInjection
{
    public static class ApiServiceCollectionExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //services.AddScoped<IApplicationDbRepository ApplicationDbRepository>();

            return services;
        }

        public static IServiceCollection AddApiDbContexts(this IServiceCollection services, IConfiguration context)
        {
            var connectionString = context.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            //services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
    }
}


