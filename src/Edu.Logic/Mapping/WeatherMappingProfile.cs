using AutoMapper;
using Edu.Logic.DTOs;
using Edu.Data.Entities;

namespace Edu.Logic.Mapping;

/// <summary>
/// AutoMapper profile for weather forecast mappings.
/// </summary>
public sealed class WeatherMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WeatherMappingProfile"/> class.
    /// </summary>
    public WeatherMappingProfile()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>();
    }
}
