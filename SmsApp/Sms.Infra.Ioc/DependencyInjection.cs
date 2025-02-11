﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sms.Application.DTOs;
using Sms.Application.Interfaces;
using Sms.Application.Services;
using Sms.Application.SubmarineSystems.Handlers;
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
            services.AddScoped<ISubmarineSystemRepository, SubmarineSystemRepository>();
            services.AddScoped<ISubmarineRepository, SubmarineRepository>();
            services.AddScoped<IMaintenanceLogRepository, MaintenanceLogRepository>();


            // Register services
            services.AddScoped<ISubmarineSystemService, SubmarineSystemService>();
            services.AddAutoMapper(typeof(SubmarineSystemDTO));

            services.AddScoped<ISubmarineService, SubmarineService>();
            services.AddAutoMapper(typeof(SubmarineDto));

            // Register authenticate
            services.AddScoped<IAuthenticate, AuthenticateService>();

            // Register MediatR handlers from assembly
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetSubmarineSystemsQueryHandler>());

            return services;
        }
    }
}
