using Sms.Infra.Ioc;
using Microsoft.Extensions.Configuration;

namespace Sms.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container (only controllers for API)
            builder.Services.AddControllers();  // Adiciona apenas os controllers para a API

            // Add the IConfiguration instance to the dependency injection container
            builder.Services.AddInfrastructure(builder.Configuration);
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                // In Development environment, use Swagger for API documentation
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Enable CORS (Cross-Origin Resource Sharing) if necessary (e.g., for frontend apps)
            app.UseCors(options =>
                options.AllowAnyOrigin()  // Allow all origins for simplicity (can be restricted in production)
                    .AllowAnyMethod()  // Allow all HTTP methods (GET, POST, PUT, DELETE)
                    .AllowAnyHeader()); // Allow all headers (can be restricted)

            // Enable routing
            app.UseRouting();

            // Enable authorization (if you have authentication or authorization mechanisms in place)
            app.UseAuthorization();

            // Map controllers to API endpoints
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
