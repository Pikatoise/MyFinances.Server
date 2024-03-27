using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MyFinances.Api
{
    /// <summary>
    /// DI services
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// Enable swagger versioning and documentation
        /// </summary>
        /// <param name="services">Collection of services for DI container</param>
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MyFinances.Api",
                    Description = "First version of MyFinances system API",
                    Contact = new OpenApiContact
                    {
                        Name = "Developer",
                        Url = new Uri("https://vk.com/pikatoise")
                    }
                });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
        }
    }
}
