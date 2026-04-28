using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RePattern.Business
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
