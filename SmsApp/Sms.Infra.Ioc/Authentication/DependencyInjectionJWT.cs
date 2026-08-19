using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using Sms.Infra.Ioc.Authentication;

namespace Sms.Infra.Ioc
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            var secretKey = configuration["Jwt:SecretKey"]
                ?? throw new InvalidOperationException("Configuration setting 'Jwt:SecretKey' was not found.");
            var localToken = environment.IsDevelopment()
                ? configuration["Jwt:LocalToken"] ?? throw new InvalidOperationException("Configuration setting 'Jwt:LocalToken' was not found.")
                : null;

            services.AddScoped<ITokenService>(_ => environment.IsDevelopment()
                ? new LocalTokenService(localToken!)
                : new JwtTokenService(configuration));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            if (context.Request.Headers.Authorization == $"Bearer {localToken}")
                            {
                                context.Principal = new ClaimsPrincipal(
                                    new ClaimsIdentity([new Claim(ClaimTypes.Name, "local-development")], context.Scheme.Name));
                                context.Success();
                            }

                            return Task.CompletedTask;
                        }
                    };
                }

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(secretKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }
    }

}
