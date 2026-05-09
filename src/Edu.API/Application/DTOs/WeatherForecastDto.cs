namespace Edu.API.Application.DTOs;

/// <summary>
/// Data transfer object for weather forecast information.
/// </summary>
public sealed record WeatherForecastDto
{
    /// <summary>
    /// Gets the unique identifier for the forecast.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    /// Gets the forecast date.
    /// </summary>
    public required DateTime Date { get; init; }

    /// <summary>
    /// Gets the temperature in Celsius.
    /// </summary>
    public required double TemperatureCelsius { get; init; }

    /// <summary>
    /// Gets the temperature in Fahrenheit.
    /// </summary>
    public required double TemperatureFahrenheit { get; init; }

    /// <summary>
    /// Gets the weather condition summary.
    /// </summary>
    public required string Summary { get; init; }

    /// <summary>
    /// Gets the location of the forecast.
    /// </summary>
    public required string Location { get; init; }

    /// <summary>
    /// Gets the humidity percentage.
    /// </summary>
    public required int Humidity { get; init; }

    /// <summary>
    /// Gets the wind speed in km/h.
    /// </summary>
    public required double WindSpeed { get; init; }
}
