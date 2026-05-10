using AutoMapper;
using Edu.Logic.DTOs;
using Edu.Logic.Services.Interfaces;
using MediatR;

namespace Edu.Logic.Queries;

/// <summary>
/// Handler for retrieving weather forecasts with optional filters.
/// </summary>
public sealed class GetWeatherForecastsQueryHandler(IWeatherService weatherService, IMapper mapper)
    : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecastDto>>
{
    /// <summary>
    /// Handles the get weather forecasts query asynchronously.
    /// </summary>
    /// <param name="request">The get weather forecasts query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of weather forecast DTOs.</returns>
    public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
    {
        var forecasts = !string.IsNullOrWhiteSpace(request.Location)
            ? await weatherService.GetForecastsByLocationAsync(request.Location, cancellationToken)
            : request.StartDate.HasValue && request.EndDate.HasValue
                ? await weatherService.GetForecastsByDateRangeAsync(request.StartDate.Value, request.EndDate.Value, cancellationToken)
                : await weatherService.GetAllForecastsAsync(cancellationToken);

        return mapper.Map<IEnumerable<WeatherForecastDto>>(forecasts);
    }
}
