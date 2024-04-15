using MyFinances.Api.Extensions;
using MyFinances.Api.Middlewares;
using MyFinances.DAL.DI;
using Serilog;

namespace MyFinances.Api
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">Exec console args</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddControllers();

            builder.Services.AddSwagger();

            builder.Services.AddDataAccessLayer(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MyFinances Swagger v1.0");
                    options.RoutePrefix = string.Empty;
                });
                app.ApplyMigrations();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseMiddleware<RequestLogContextMiddleware>();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
