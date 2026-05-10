namespace Edu.Data.Entities;

/// <summary>
/// Represents a weather forecast entity.
/// </summary>
public sealed class WeatherForecast
{
    /// <summary>
    /// Gets the unique identifier for the forecast.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets the forecast date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets the temperature in Celsius.
    /// </summary>
    public double TemperatureCelsius { get; set; }

    /// <summary>
    /// Gets the temperature in Fahrenheit.
    /// </summary>
    public double TemperatureFahrenheit => TemperatureCelsius * 9 / 5 + 32;

    /// <summary>
    /// Gets the weather condition summary.
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Gets the location of the forecast.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets the humidity percentage.
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Gets the wind speed in km/h.
    /// </summary>
    public double WindSpeed { get; set; }
}
