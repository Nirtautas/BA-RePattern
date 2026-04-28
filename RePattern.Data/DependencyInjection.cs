using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RePattern.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
