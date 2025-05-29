using Microsoft.OpenApi.Models;

namespace OrderPackagingService.Api.Extensions.Services
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "OrderPackagingService API", 
                    Version = "v1",
                    Description = "An API to handle packing service.",
                    TermsOfService = new Uri("https://example.com/terms"),

                    Contact = new OpenApiContact 
                    { 
                        Name = "Marcos Allysson",
                        //Email = "",
                        Url = new Uri("https://www.linkedin.com/in/marcosallysson/?locale=en_US")
                    },

                    License = new OpenApiLicense 
                    {
                        Name = "Project API",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please, enter JWT with Bearer into field.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
