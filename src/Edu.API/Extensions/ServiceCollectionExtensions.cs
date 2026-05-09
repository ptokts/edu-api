using Edu.API.Application.Mapping;
using Edu.API.Application.Queries;
using Edu.API.Application.Validators;
using Edu.API.Infrastructure.Repositories;
using FluentValidation;

namespace Edu.API.Extensions;

/// <summary>
/// Extension methods for service collection configuration.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds OpenAPI/Swagger services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddApiOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi();
        return services;
    }

    /// <summary>
    /// Adds problem details services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddApiProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails();
        return services;
    }

    /// <summary>
    /// Adds application services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register repositories
        services.AddScoped<IWeatherRepository, MockWeatherRepository>();

        // Register MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherForecastsQuery).Assembly));

        // Register AutoMapper
        services.AddAutoMapper(typeof(WeatherMappingProfile));

        // Register FluentValidation
        services.AddValidatorsFromAssemblyContaining<GetWeatherForecastsQueryValidator>();

        return services;
    }
}
