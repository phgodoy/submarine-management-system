using Sms.Infra.Ioc;
using Microsoft.AspNetCore.Identity;
using Sms.Infra.Data.Context;
using Sms.Infra.Data.Identity;
using Sms.Domain.Accont;
using Microsoft.EntityFrameworkCore;

namespace Sms.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            // Add services to the container (only controllers for API)
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

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

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                await dbContext.Database.MigrateAsync();

                var seed = services.GetRequiredService<ISeedUserRoleInitial>();
                await seed.SeedRolesAsync();
                await seed.SeedUsersAsync();
            }

            // Log o ambiente atual
            app.Logger.LogInformation("Starting application in {Environment} environment.", app.Environment.EnvironmentName);

            // Configure the HTTP request pipeline
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sms.WebApi v1");
                options.RoutePrefix = "swagger";
            });

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
            await app.RunAsync();
        }
    }
}
