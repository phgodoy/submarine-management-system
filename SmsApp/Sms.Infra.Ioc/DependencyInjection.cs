using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using Sms.Application.Services;
using Sms.Application.SubmarineSystems.Commands;
using Sms.Application.SubmarineSystems.Handlers;
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

            // Register services
            services.AddScoped<ISubmarineSystemService, SubmarineSystemService>();
            services.AddAutoMapper(typeof(SubmarineSystemDTO));

            // Register other necessary services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSubmarineSystemsQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSubmarineSystemByIdQueryHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSubmarineSystemCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateSubmarineSystemCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DisableSubmarineSystemCommandHandler).Assembly));

            return services;
        }
    }
}
