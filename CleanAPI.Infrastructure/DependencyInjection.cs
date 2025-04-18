using CleanAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer("Server=localhost;Database=Test_CleanAPI;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
        });
        return services;
    }
}
