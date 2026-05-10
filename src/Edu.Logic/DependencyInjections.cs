using Edu.Data.Repositories;
using Edu.Data.Repositories.Interfaces;
using Edu.Logic.Mapping;
using Edu.Logic.Queries;
using Edu.Logic.Services;
using Edu.Logic.Validators;
using Edu.Logic.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Edu.Logic;

/// <summary>
/// Extension methods for application layer service collection configuration.
/// </summary>
public static class DependencyInjections
{
    /// <summary>
    /// Adds application layer services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        // Register repositories
        services.AddScoped<IWeatherRepository, MockWeatherRepository>();

        // Register services
        services.AddScoped<IWeatherService, WeatherService>();

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherForecastsQuery).Assembly));

        // Register AutoMapper
        services.AddAutoMapper(typeof(WeatherMappingProfile));

        // Register FluentValidation
        services.AddValidatorsFromAssemblyContaining<GetWeatherForecastsQueryValidator>();

        return services;
    }
}
