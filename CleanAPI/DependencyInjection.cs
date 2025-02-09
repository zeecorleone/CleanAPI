using CleanAPI.Application;
using CleanAPI.Infrastructure;

namespace CleanAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddDI(this IServiceCollection services)
    {
        services.AddApplicationDI()
            .AddInfrastructureDI();

        return services;
    }
}
