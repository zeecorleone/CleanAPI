
using CleanAPI.Core.Interfaces;
using CleanAPI.Core.Models;
using CleanAPI.Infrastructure.Services;

namespace CleanAPI.Infrastructure.Repositories;

public class GoWeatherRepository : IGoWeatherRepository
{
    private readonly GoWeatherHttpClientService _goWeatherHttpClientService;
    public GoWeatherRepository(GoWeatherHttpClientService goWeatherHttpClientService)
    {
        _goWeatherHttpClientService = goWeatherHttpClientService;
    }
    public Task<GoWeatherForecastDto> GetWeatherForecastSummaryByCityAsync(string city)
    {
        return _goWeatherHttpClientService.GetWeatherSummary(city);
    }
}
