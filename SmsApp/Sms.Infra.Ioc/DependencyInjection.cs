using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Context;
using Sms.Infra.Data.Repositories;

namespace Sms.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<ISubmarineSystemRepository, SubmarineSystemRepository>();

            // Register other necessary services
            return services;
        }
    }
}
