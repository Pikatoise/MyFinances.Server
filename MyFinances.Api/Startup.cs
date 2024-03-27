using Asp.Versioning;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace MyFinances.Api
{
    public static class Startup
    {
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

                //options.OperationFilter<SwaggerDefaultValues>();

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
        }
    }

    /*public class SwaggerDefaultValues: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;
            operation.Parameters ??= new List<OpenApiParameter>();

            // Добавляем параметр с текущей версией API в тело запроса
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "api-version",
                In = ParameterLocation.Query,
                Required = true,
                Schema = new OpenApiSchema { Type = "string" },
                Description = "API version",
            });
        }
    }*/
}
