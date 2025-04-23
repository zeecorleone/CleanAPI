

using CleanAPI.Core.Models;

namespace CleanAPI.Core.Interfaces;

public interface IGoWeatherRepository
{
    Task<GoWeatherForecastDto> GetWeatherForecastSummaryByCityAsync(string city);
}
