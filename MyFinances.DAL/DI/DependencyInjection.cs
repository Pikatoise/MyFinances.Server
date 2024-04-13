using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyFinances.DAL.Interceptors;
using MyFinances.DAL.Repositories;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Repositories;

namespace MyFinances.DAL.DI
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("pgConn");

            services.AddSingleton<DateInterceptor>();
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseNpgsql(connectionString);
                options.AddInterceptors(sp.GetRequiredService<DateInterceptor>());
            });

            services.InitRepositories();

            //services.LogDatabaseAvailability();
        }

        private static void InitRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<UserRole>, BaseRepository<UserRole>>();
            services.AddScoped<IBaseRepository<UserToken>, BaseRepository<UserToken>>();
            services.AddScoped<IBaseRepository<Role>, BaseRepository<Role>>();
            services.AddScoped<IBaseRepository<TypeAssociation>, BaseRepository<TypeAssociation>>();
            services.AddScoped<IBaseRepository<OperationType>, BaseRepository<OperationType>>();
            services.AddScoped<IBaseRepository<Plan>, BaseRepository<Plan>>();
            services.AddScoped<IBaseRepository<Period>, BaseRepository<Period>>();
            services.AddScoped<IBaseRepository<Operation>, BaseRepository<Operation>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void LogDatabaseAvailability(this IServiceCollection services)
        {
            var logger = services.BuildServiceProvider().GetService<ILogger>();

            if (logger != null)
            {
                var dbStatus = services.BuildServiceProvider().GetRequiredService<IUnitOfWork>().IsRun();
                logger.LogInformation($"Database status: {dbStatus}");
            }
        }
    }
}
