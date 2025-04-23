

using CleanAPI.Core.Interfaces;
using CleanAPI.Core.Models;
using MediatR;

namespace CleanAPI.Application.Queries;

public record GetWeatherSummaryQuery(string city) : IRequest<GoWeatherForecastDto>;

public class GetWeatherSummaryQueryHandler : IRequestHandler<GetWeatherSummaryQuery, GoWeatherForecastDto>
{
    private readonly IGoWeatherRepository _goWeatherRepository;

    public GetWeatherSummaryQueryHandler(IGoWeatherRepository goWeatherRepository)
    {
        _goWeatherRepository = goWeatherRepository;
    }

    public async Task<GoWeatherForecastDto> Handle(GetWeatherSummaryQuery request, CancellationToken cancellatioToken)
    {
        return await _goWeatherRepository.GetWeatherForecastSummaryByCityAsync(request.city);
    }
}

