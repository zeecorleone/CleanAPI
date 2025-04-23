
namespace CleanAPI.Core.Models;

public class GoWeatherForecastDto
{
    public string Temperature { get; set; }
    public string Wind { get; set; }
    public string Description { get; set; }
    public List<GoForecastDayDto> Forecast { get; set; }
}

public class GoForecastDayDto
{
    public string Day { get; set; }
    public string Temperature { get; set; }
    public string Wind { get; set; }
}