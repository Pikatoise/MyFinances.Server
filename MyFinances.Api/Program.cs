using MyFinances.Api.Extensions;
using MyFinances.Api.Middlewares;
using MyFinances.Application.DI;
using MyFinances.DAL.DI;
using MyFinances.Domain.Settings;
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

            builder.Configuration.AddUserSecrets<Program>();

            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(JwtSettings.DefaultSection));

            builder.Services.AddAuth(builder);

            builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddOptions<FixerSettings>()
                .BindConfiguration(FixerSettings.ConfigurationSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            builder.Services.AddControllers();

            builder.Services.AddSwagger();

            builder.Services.AddDataAccessLayer(builder.Configuration);
            builder.Services.AddApplication();

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

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append(
                        "Cache-Control", $"public, max-age={60 * 60 * 24 * 7}");
                }
            });

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
