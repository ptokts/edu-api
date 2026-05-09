using Edu.API.Application.DTOs;
using Edu.API.Application.Queries;
using MediatR;

namespace Edu.API.WebApi.Endpoints;

/// <summary>
/// Weather forecast API endpoints.
/// </summary>
public static class WeatherEndpoints
{
    /// <summary>
    /// Maps weather forecast endpoints.
    /// </summary>
    /// <param name="app">The web application builder.</param>
    public static void MapWeatherEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/weather")
            .WithName("Weather");

        group.MapGet("/forecasts", GetForecasts)
            .WithName("GetForecasts")
            .WithDescription("Get weather forecasts with optional filters");

        group.MapGet("/forecasts/{id}", GetForecastById)
            .WithName("GetForecastById") // Name applied directly to the endpoint
            .WithDescription("Get a specific weather forecast by ID");
    }

    private static RouteGroupBuilder MapGetForecasts(this RouteGroupBuilder group)
    {
        group.MapGet("/forecasts", GetForecasts);
        return group;
    }

    private static RouteGroupBuilder MapGetForecastById(this RouteGroupBuilder group)
    {
        group.MapGet("/forecasts/{id}", GetForecastById);
        return group;
    }

    private static async Task<IResult> GetForecasts(
        IMediator mediator,
        string? location = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetWeatherForecastsQuery
            {
                Location = location,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message, statusCode: 500);
        }
    }

    private static async Task<IResult> GetForecastById(
        int id,
        IMediator mediator,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var query = new GetWeatherForecastsQuery();
            var forecasts = await mediator.Send(query, cancellationToken);
            var forecast = forecasts.FirstOrDefault(f => f.Id == id);

            return forecast is not null
                ? Results.Ok(forecast)
                : Results.NotFound($"Forecast with ID {id} not found.");
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message, statusCode: 500);
        }
    }
}
