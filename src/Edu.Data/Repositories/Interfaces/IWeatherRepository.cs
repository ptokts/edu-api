using Edu.Data.Entities;

namespace Edu.Data.Repositories.Interfaces;

/// <summary>
/// Interface for weather repository operations.
/// </summary>
public interface IWeatherRepository
{
    /// <summary>
    /// Gets all weather forecasts asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of all weather forecasts.</returns>
    Task<IEnumerable<WeatherForecast>> GetAllForecastsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets weather forecasts by location asynchronously.
    /// </summary>
    /// <param name="location">The location to filter by.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts for the specified location.</returns>
    Task<IEnumerable<WeatherForecast>> GetForecastsByLocationAsync(string location, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a weather forecast by ID asynchronously.
    /// </summary>
    /// <param name="id">The forecast ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The weather forecast if found; otherwise null.</returns>
    Task<WeatherForecast?> GetForecastByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets weather forecasts within a date range asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts within the date range.</returns>
    Task<IEnumerable<WeatherForecast>> GetForecastsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
}
