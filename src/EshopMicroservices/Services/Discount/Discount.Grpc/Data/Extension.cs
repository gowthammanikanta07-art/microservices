using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Data
{
    public static class Extension
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            context.Database.MigrateAsync();
            return app;
        }
    }
}
