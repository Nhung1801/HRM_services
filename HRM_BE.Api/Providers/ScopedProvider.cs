using HRM_BE.Api.Services;
using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Data.Repositories;
using HRM_BE.Data.SeedWorks;


namespace HRM_BE.Api.Providers
{
    public static class ScopedProvider
    {



        public static IServiceCollection AddScopedProvider(this IServiceCollection services)
        {

            var servicesR = typeof(BannerRepository).Assembly.GetTypes()
            .Where(x => x.GetInterfaces().Any(i => i.Name == typeof(Core.ISeedWorks.IRepositoryBase<,>).Name) && !x.IsAbstract && x.IsClass && !x.IsGenericType);

            foreach (var service in servicesR)
            {
                var allInterfaces = service.GetInterfaces();
                var directInterface = allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces())).FirstOrDefault();
                if (directInterface != null)
                {
                    services.Add(new ServiceDescriptor(directInterface, service, ServiceLifetime.Scoped));
                }
            }


            services.AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped(typeof(RepositoryBase<,>), typeof(RepositoryBase<,>))




            .AddScoped<IFileService, FileService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IJobHangFireService, JobHangFireService>();
            services.AddScoped<IPermissionService, PermissionService>();

            return services;
        }
    }

}
