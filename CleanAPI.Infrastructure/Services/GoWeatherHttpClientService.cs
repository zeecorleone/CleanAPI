
using CleanAPI.Core.Models;
using System.Net.Http.Json;

namespace CleanAPI.Infrastructure.Services;

public class GoWeatherHttpClientService
{
    private readonly HttpClient _httpClient;
    public GoWeatherHttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<GoWeatherForecastDto> GetWeatherSummary(string city)
    {
        return await _httpClient.GetFromJsonAsync<GoWeatherForecastDto>($"weather/{city}");
    }
}
