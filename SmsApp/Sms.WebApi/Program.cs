using Sms.Infra.Ioc;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

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

            // Add Swagger (configurado para ser habilitado em produção, caso necessário)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add infrastructure services
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            // Log o ambiente atual
            app.Logger.LogInformation("Starting application in {Environment} environment.", app.Environment.EnvironmentName);

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment() || app.Configuration.GetValue<bool>("EnableSwaggerInProduction"))
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors(options =>
                options.WithOrigins("https://example.com", "https://anotherdomain.com")
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            // Enable authorization (if necessary)
            app.UseAuthorization();

            // Map controllers to API endpoints
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
