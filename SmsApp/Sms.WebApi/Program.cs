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

            // Add Swagger (configurado para ser habilitado em produção, caso necessário)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add infrastructure services (certifique-se de que a implementação de AddInfrastructure está correta)
            builder.Services.AddInfrastructure(builder.Configuration);

            // Add identity - certifique-se de usar a classe de usuário customizada se necessário
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()  // Usando ApplicationUser em vez de IdentityUser
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

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

            // Enable CORS (aqui você pode adicionar os domínios que deseja permitir)
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
