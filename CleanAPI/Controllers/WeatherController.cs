using CleanAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController(ISender sender) : ControllerBase
    {
        [HttpGet("summary/{city}")]
        public async Task<IActionResult> GetWeatherSummary(string city)
        {
            var result = await sender.Send(new GetWeatherSummaryQuery(city));
            if(result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
