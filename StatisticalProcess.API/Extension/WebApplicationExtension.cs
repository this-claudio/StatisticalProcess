using Microsoft.EntityFrameworkCore;
using StatisticalProcess.Infrastructure.EntityFramework.Context;

namespace StatisticalProcess.API.Extension
{
    public static class WebApplicationExtension
    {
        public static void ConfigureApps(WebApplication app)
        {
            app.UseCors("AllowAll");

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();

                var pendingMigrations = dbContext.Database.GetPendingMigrations();

                if (pendingMigrations.Any())
                {
                    dbContext.Database.Migrate();
                    Console.WriteLine($"Pending Migration Executed: {string.Join(", ", pendingMigrations)}");
                }
            }
        }
    }
}
