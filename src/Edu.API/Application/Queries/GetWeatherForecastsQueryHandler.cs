using AutoMapper;
using Edu.API.Application.DTOs;
using Edu.API.Infrastructure.Repositories;
using MediatR;

namespace Edu.API.Application.Queries;

/// <summary>
/// Handler for retrieving weather forecasts with optional filters.
/// </summary>
public sealed class GetWeatherForecastsQueryHandler(IWeatherRepository weatherRepository, IMapper mapper)
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
        IEnumerable<dynamic> forecasts = [];

        if (!string.IsNullOrWhiteSpace(request.Location))
        {
            forecasts = await weatherRepository.GetForecastsByLocationAsync(request.Location, cancellationToken);
        }
        else if (request.StartDate.HasValue && request.EndDate.HasValue)
        {
            forecasts = await weatherRepository.GetForecastsByDateRangeAsync(request.StartDate.Value, request.EndDate.Value, cancellationToken);
        }
        else
        {
            forecasts = await weatherRepository.GetAllForecastsAsync(cancellationToken);
        }

        return mapper.Map<IEnumerable<WeatherForecastDto>>(forecasts);
    }
}
