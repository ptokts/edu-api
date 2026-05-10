using Edu.Api.Middleware;
using Edu.Api.WebApi.Endpoints;
using Edu.Logic;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddLogic();
builder.Services.AddLogic();
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
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
