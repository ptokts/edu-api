using AutoMapper;
using Edu.API.Application.DTOs;
using Edu.API.Domain.Entities;

namespace Edu.API.Application.Mapping;

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
