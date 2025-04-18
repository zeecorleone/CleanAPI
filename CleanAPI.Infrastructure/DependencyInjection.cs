using CleanAPI.Core.Interfaces;
using CleanAPI.Infrastructure.Data;
using CleanAPI.Infrastructure.Repositories;
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

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
