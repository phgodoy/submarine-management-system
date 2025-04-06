using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sms.Application.Interfaces;
using Sms.Application.Services;
using Sms.Application.Dtos;
using Sms.Domain.Accont;
using Sms.Domain.Interfaces;
using Sms.Infra.Data.Context;
using Sms.Infra.Data.Identity;
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
            services.AddScoped<ISubmarineRepository, SubmarineRepository>();  
            services.AddScoped<ISubmarineSystemRepository, SubmarineSystemRepository>();
            
            // Register services
            services.AddScoped<ISubmarineService, SubmarineService>();
            services.AddScoped<ISubmarineSystemService, SubmarineSystemService>();
            services.AddAutoMapper(typeof(SubmarineDto));

            // Register authenticate
            services.AddScoped<IAuthenticate, AuthenticateService>();

            // Register MediatR handlers from assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SubmarineService).Assembly));

            return services;
        }
    }
}
