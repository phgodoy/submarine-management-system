using Sms.Infra.Ioc;
using Microsoft.Extensions.Configuration;

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
            else
            {
                // Opcional: Habilitar Swagger em produção apenas com uma configuração segura
                var enableSwaggerInProduction = app.Configuration.GetValue<bool>("EnableSwaggerInProduction");
                if (enableSwaggerInProduction)
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
            }

            // Enable HTTPS redirection
            app.UseHttpsRedirection();

            // Enable CORS
            app.UseCors(options =>
                options.WithOrigins("https://example.com", "https://anotherdomain.com") // Permitir apenas os domínios confiáveis
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            // Enable routing
            app.UseRouting();

            // Enable authorization (if necessary)
            app.UseAuthorization();

            // Map controllers to API endpoints
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
