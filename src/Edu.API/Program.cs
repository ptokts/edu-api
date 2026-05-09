using Edu.API.Extensions;
using Edu.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddApiOpenApi();
builder.Services.AddApiProblemDetails();
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

app.Run();
