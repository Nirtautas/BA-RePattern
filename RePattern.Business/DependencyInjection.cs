using Microsoft.Extensions.Configuration;
using RePattern.Business.AutoMapper;
using RePattern.Business.Services.Concrete;
using RePattern.Business.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
