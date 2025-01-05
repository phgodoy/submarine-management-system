using Sms.Infra.Ioc;
using Microsoft.AspNetCore.Identity;
using Sms.Infra.Data.Context;
using Sms.Infra.Data.Identity;

namespace Sms.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Log inicial
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container (only controllers for API)
            builder.Services.AddControllers();

            // Add Swagger
            builder.Services.AddInfrastructureSwagger();

            // Add infrastructure services
            builder.Services.AddInfrastructure(builder.Configuration);

            // Add identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure JWT authentication
            builder.Services.AddInfrastructureJWT(builder.Configuration);

            var app = builder.Build();

            // Log o ambiente atual
            app.Logger.LogInformation("Starting application in {Environment} environment.", app.Environment.EnvironmentName);

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable HTTPS redirection
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            // Enable authentication and authorization
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // Map controllers to API endpoints
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
