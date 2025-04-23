using CleanAPI.Application;
using CleanAPI.Core;
using CleanAPI.Infrastructure;

namespace CleanAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationDI()
            .AddInfrastructureDI()
            .AddCoreDI(configuration);

        return services;
    }
}
