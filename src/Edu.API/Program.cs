using Edu.API.Extensions;
using Edu.API.Middleware;
using Edu.API.WebApi.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddApiOpenApi();
builder.Services.AddApiProblemDetails();
builder.Services.AddApplicationServices();
builder.Services.AddScoped<GlobalExceptionHandler>();

var app = builder.Build();

// Use middleware
app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Map endpoints
app.MapWeatherEndpoints();

app.Run();
