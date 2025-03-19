using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace RestaurantAPI.WebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Restaurant API",
                    Description = "API para una aplicación de comida de un restaurante",
                    Contact = new OpenApiContact 
                    { 
                        Name = "Rainel Ramírez",
                        Email = "20231054@itla.edu.do",
                        Url = new Uri("https://www.itla.edu.do")
                    }
                });

                options.DescribeAllParametersInCamelCase();
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
