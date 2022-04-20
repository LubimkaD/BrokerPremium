using BrokerPremium.Core.Contracts;
using BrokerPremium.Infrastructure.Data;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Warehouse.Core.Services;

namespace Micrososft.Extensions.DependecyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContexts(this IServiceCollection services, IConfiguration context)
        {
            var connectionString = context.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();
            return services;
        }
    }
}
