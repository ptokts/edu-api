using Microsoft.Extensions.DependencyInjection;

namespace Edu.Data;

/// <summary>
/// Extension methods for data layer service collection configuration.
/// </summary>
public static class DependencyInjections
{
    /// <summary>
    /// Adds data layer services to the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>The service collection for chaining.</returns>
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        // Data layer services can be registered here
        // Currently, repositories are registered in the Application layer for simplicity

        return services;
    }
}
