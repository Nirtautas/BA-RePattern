using Microsoft.Extensions.Configuration;
using RePattern.Business.AutoMapper;
using RePattern.Business.Services.Concrete;
using RePattern.Business.Services.Interfaces;
using RePattern.Business.Utils;
using RePattern.Business.Utils.EmailService;
using RePattern.Business.Utils.EmailService.Interfaces;
using RePattern.Business.Utils.EmailService.Services;
using RePattern.Business.Utils.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddScoped<IEmailService, EmailContextService>();

            services
                .AddScoped<GmailServiceStrategy>()
                .AddScoped<IJwtTokenGenerator, JwtTokenGenerator>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IBadgeService, BadgeService>()
                .AddScoped<IBadgeAcquisitionService, BadgeAcquisitionService>();

            return services;
        }
    }
}
