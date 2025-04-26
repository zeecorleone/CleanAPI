using CleanAPI.Application.Interfaces;
using CleanAPI.Core.Interfaces;
using CleanAPI.Core.Options;
using CleanAPI.Infrastructure.Data;
using CleanAPI.Infrastructure.Repositories;
using CleanAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CleanAPI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
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
        services.AddScoped<IGoWeatherRepository, GoWeatherRepository>();
        services.AddScoped<IEmailService, EmailService>();

        services.AddHttpClient<GoWeatherHttpClientService>((provider, options) =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            options.BaseAddress = new Uri(configuration["GoWeatherAPI:BaseUrl"]);
        });

        return services;
    }
}
