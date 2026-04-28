using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RePattern.Api.Utils;
using System.Text;
using System.Text.Json;

namespace RePattern.Api.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder)
        {
            var keyValue = ConfigUtils.GetRequiredConfigValue(builder.Configuration, "RePatternJwtKey");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = ConfigUtils.GetRequiredConfigValue(builder.Configuration, "RePatternIssuer"),
                    ValidateIssuer = true,

                    ValidAudience = ConfigUtils.GetRequiredConfigValue(builder.Configuration, "RePatternAudience"),
                    ValidateAudience = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue!)),
                    ValidateIssuerSigningKey = true,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
                };
                options.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        context.HandleResponse();

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        var isExpired = context.AuthenticateFailure is SecurityTokenExpiredException;

                        var response = new
                        {
                            message = "Token Expired",
                            code = "TOKEN_EXPIRED",
                        };

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                };
            });

            return builder;
        }
    }
}

