namespace Ordering.API
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApiService(this IServiceCollection services)
        {
            //services.AddCarter();
            return services;
        }

        public static WebApplication UseApiServices(this WebApplication application)
        {
            //application.UseCarter();
            //application.UseHealthChecks();

            return application;
        }
    }
}
