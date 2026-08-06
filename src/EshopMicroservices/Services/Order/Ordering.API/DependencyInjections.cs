using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.API
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter();
            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Database")!);
    
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();
            app.UseHealthChecks("/health",
                new HealthCheckOptions()
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            return app;
        }
    }
}
