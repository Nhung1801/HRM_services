using HRM_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace HRM_BE.Api.Managers
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<HrmContext>())
                {
                    context.Database.Migrate();
                    //new DataSeeder().SeedAsync(context).Wait();
                }
            }
            return app;
        }
    }
}
