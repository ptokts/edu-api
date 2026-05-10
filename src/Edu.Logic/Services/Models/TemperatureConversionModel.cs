namespace Edu.Logic.Services.Models;

/// <summary>
/// Represents temperature conversion between Celsius and Fahrenheit.
/// </summary>
public sealed record TemperatureConversionModel
{
    /// <summary>
    /// Gets the temperature in Celsius.
    /// </summary>
    public required double Celsius { get; init; }

    /// <summary>
    /// Gets the temperature in Fahrenheit.
    /// </summary>
    public required double Fahrenheit { get; init; }

    /// <summary>
    /// Creates a temperature conversion model from Celsius.
    /// </summary>
    /// <param name="celsius">The temperature in Celsius.</param>
    /// <returns>A temperature conversion model with both Celsius and Fahrenheit values.</returns>
    public static TemperatureConversionModel FromCelsius(double celsius)
    {
        return new TemperatureConversionModel
        {
            Celsius = celsius,
            Fahrenheit = celsius * 9 / 5 + 32
        };
    }

    /// <summary>
    /// Creates a temperature conversion model from Fahrenheit.
    /// </summary>
    /// <param name="fahrenheit">The temperature in Fahrenheit.</param>
    /// <returns>A temperature conversion model with both Celsius and Fahrenheit values.</returns>
    public static TemperatureConversionModel FromFahrenheit(double fahrenheit)
    {
        return new TemperatureConversionModel
        {
            Celsius = (fahrenheit - 32) * 5 / 9,
            Fahrenheit = fahrenheit
        };
    }
}
