using CleanAPI.Core.Interfaces;
using CleanAPI.Core.Options;
using CleanAPI.Infrastructure.Data;
using CleanAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CleanAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<AppDbContext>(options =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //});

        services.AddDbContext<AppDbContext>((provider, options) =>
        {
            options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}
