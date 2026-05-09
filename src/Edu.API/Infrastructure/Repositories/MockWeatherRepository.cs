using Edu.API.Domain.Entities;

namespace Edu.API.Infrastructure.Repositories;

/// <summary>
/// Mock implementation of the weather repository with sample data.
/// </summary>
public sealed class MockWeatherRepository : IWeatherRepository
{
    private readonly List<WeatherForecast> _forecasts = new()
    {
        new WeatherForecast
        {
            Id = 1,
            Date = DateTime.Today.AddDays(1),
            TemperatureCelsius = 20,
            Summary = "Partly cloudy",
            Location = "New York",
            Humidity = 65,
            WindSpeed = 15
        },
        new WeatherForecast
        {
            Id = 2,
            Date = DateTime.Today.AddDays(2),
            TemperatureCelsius = 22,
            Summary = "Sunny",
            Location = "Los Angeles",
            Humidity = 45,
            WindSpeed = 10
        },
        new WeatherForecast
        {
            Id = 3,
            Date = DateTime.Today.AddDays(3),
            TemperatureCelsius = 18,
            Summary = "Rainy",
            Location = "Chicago",
            Humidity = 85,
            WindSpeed = 20
        },
        new WeatherForecast
        {
            Id = 4,
            Date = DateTime.Today.AddDays(4),
            TemperatureCelsius = 21,
            Summary = "Cloudy",
            Location = "New York",
            Humidity = 70,
            WindSpeed = 12
        },
        new WeatherForecast
        {
            Id = 5,
            Date = DateTime.Today.AddDays(5),
            TemperatureCelsius = 25,
            Summary = "Clear",
            Location = "Los Angeles",
            Humidity = 40,
            WindSpeed = 8
        }
    };

    /// <summary>
    /// Gets all weather forecasts asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of all weather forecasts.</returns>
    public Task<IEnumerable<WeatherForecast>> GetAllForecastsAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<WeatherForecast>>(_forecasts.AsReadOnly());
    }

    /// <summary>
    /// Gets weather forecasts by location asynchronously.
    /// </summary>
    /// <param name="location">The location to filter by.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts for the specified location.</returns>
    public Task<IEnumerable<WeatherForecast>> GetForecastsByLocationAsync(string location, CancellationToken cancellationToken = default)
    {
        var result = _forecasts.Where(f => f.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
        return Task.FromResult<IEnumerable<WeatherForecast>>(result);
    }

    /// <summary>
    /// Gets a weather forecast by ID asynchronously.
    /// </summary>
    /// <param name="id">The forecast ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The weather forecast if found; otherwise null.</returns>
    public Task<WeatherForecast?> GetForecastByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = _forecasts.FirstOrDefault(f => f.Id == id);
        return Task.FromResult<WeatherForecast?>(result);
    }

    /// <summary>
    /// Gets weather forecasts within a date range asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts within the date range.</returns>
    public Task<IEnumerable<WeatherForecast>> GetForecastsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        var result = _forecasts.Where(f => f.Date >= startDate && f.Date <= endDate).ToList();
        return Task.FromResult<IEnumerable<WeatherForecast>>(result);
    }
}
