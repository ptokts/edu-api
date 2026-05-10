using Edu.Logic.Services.Models;
using Edu.Data.Entities;
using Edu.Data.Repositories;
using Edu.Data.Repositories.Interfaces;
using Edu.Logic.Services.Interfaces;

namespace Edu.Logic.Services;

/// <summary>
/// Service for weather operations.
/// </summary>
public sealed class WeatherService(IWeatherRepository weatherRepository) : IWeatherService
{
    /// <summary>
    /// Gets all weather forecasts asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of all weather forecasts.</returns>
    public async Task<IEnumerable<WeatherForecast>> GetAllForecastsAsync(CancellationToken cancellationToken = default)
    {
        return await weatherRepository.GetAllForecastsAsync(cancellationToken);
    }

    /// <summary>
    /// Gets weather forecasts by location asynchronously.
    /// </summary>
    /// <param name="location">The location to filter by.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts for the specified location, or an empty collection if location is invalid.</returns>
    public async Task<IEnumerable<WeatherForecast>> GetForecastsByLocationAsync(string location, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            return [];
        }

        return await weatherRepository.GetForecastsByLocationAsync(location, cancellationToken);
    }

    /// <summary>
    /// Gets a weather forecast by ID asynchronously.
    /// </summary>
    /// <param name="id">The forecast ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The weather forecast if found and ID is valid; otherwise null.</returns>
    public async Task<WeatherForecast?> GetForecastByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        if (id <= 0)
        {
            return null;
        }

        return await weatherRepository.GetForecastByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Gets weather forecasts within a date range asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts within the date range, or an empty collection if date range is invalid.</returns>
    public async Task<IEnumerable<WeatherForecast>> GetForecastsByDateRangeAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        if (startDate > endDate)
        {
            return [];
        }

        return await weatherRepository.GetForecastsByDateRangeAsync(startDate, endDate, cancellationToken);
    }

    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit and vice versa.
    /// </summary>
    /// <param name="celsius">The temperature in Celsius.</param>
    /// <returns>A temperature conversion model.</returns>
    public TemperatureConversionModel ConvertTemperature(double celsius)
    {
        return TemperatureConversionModel.FromCelsius(celsius);
    }

    /// <summary>
    /// Gets weather forecasts within a date range with temperature conversions asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A collection of forecasts within the date range.</returns>
    public async Task<IEnumerable<WeatherForecast>> GetForecastsByDateRangeWithConversionsAsync(DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
    {
        return await GetForecastsByDateRangeAsync(startDate, endDate, cancellationToken);
    }
}
