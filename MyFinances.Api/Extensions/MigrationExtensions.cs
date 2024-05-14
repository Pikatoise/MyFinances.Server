using Microsoft.EntityFrameworkCore;
using MyFinances.DAL;

namespace MyFinances.Api.Extensions
{
    /// <summary>
    /// Extensions for database migrations
    /// </summary>
    public static class MigrationExtensions
    {
        /// <summary>
        /// Apply last created migration at app startup, if not applied
        /// </summary>
        /// <param name="app">Application builder</param>
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Database.CanConnect())
                dbContext.Database.Migrate();
            //dbContext.Database.EnsureCreated();
        }
    }
}
