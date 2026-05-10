using Edu.Logic.DTOs;
using MediatR;

namespace Edu.Logic.Queries;

/// <summary>
/// Query to retrieve weather forecasts with optional filters.
/// </summary>
public sealed record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecastDto>>
{
    /// <summary>
    /// Gets the location filter (optional).
    /// </summary>
    public string? Location { get; init; }

    /// <summary>
    /// Gets the start date filter (optional).
    /// </summary>
    public DateTime? StartDate { get; init; }

    /// <summary>
    /// Gets the end date filter (optional).
    /// </summary>
    public DateTime? EndDate { get; init; }
}
