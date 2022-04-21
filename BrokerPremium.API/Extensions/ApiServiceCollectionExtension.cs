using BrokerPremium.Core.Contracts;
using BrokerPremium.Core.Services;
using BrokerPremium.Infrastructure.Data;
using BrokerPremium.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Micrososft.Extensions.DependecyInjection
{
    public static class ApiServiceCollectionExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<ICustomerClaimService, CustomerClaimService>();

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


