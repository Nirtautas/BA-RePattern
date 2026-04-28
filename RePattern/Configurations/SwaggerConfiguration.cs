using Microsoft.OpenApi;

namespace RePattern.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static WebApplicationBuilder ConfigureSwagger(this WebApplicationBuilder builder)
        {

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RePattern API",
                    Version = "v1"
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter JWT token only."
                };

                options.AddSecurityDefinition("Bearer", securityScheme);

                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference("Bearer", document)] = []
                });
            });

            return builder;
        }
    }
}
