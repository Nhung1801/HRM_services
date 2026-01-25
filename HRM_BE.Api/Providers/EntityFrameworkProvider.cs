using HRM_BE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HRM_BE.Api.Providers
{
    public static class EntityFrameworkProvider
    {
        public static IServiceCollection AddEntityFrameworkProvider(this IServiceCollection services, WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HrmContext>(options =>
            {
                options.UseSqlServer(connectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.UseHierarchyId();
                    sqlServerOptionsAction.CommandTimeout(30);
                    //sqlServerOptionsAction.EnableRetryOnFailure(3);

                });
                options.EnableDetailedErrors(true);
                options.EnableSensitiveDataLogging(true);
            }, ServiceLifetime.Transient);

            return services;
        }
    }
}
