using Microsoft.AspNetCore.Mvc;

namespace Edu.API.Middleware;

/// <summary>
/// Global exception handler middleware for logging and handling unhandled exceptions.
/// </summary>
public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IMiddleware
{
    /// <summary>
    /// Invokes the middleware.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="next">The next middleware delegate.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(
                exception,
                "Unhandled exception occurred. Method: {Method}, Path: {Path}, User: {User}",
                context.Request.Method,
                context.Request.Path,
                context.User.Identity?.Name ?? "Anonymous");

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/problem+json";

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An unexpected error occurred",
                    Detail = "Please contact support if the problem persists.",
                    Instance = context.Request.Path,
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
