# Edu.API

A minimal .NET 10 ASP.NET Core Web API for educational purposes.

## Prerequisites

- .NET 10 SDK or later

## Build

```bash
dotnet build
```

## Run

```bash
cd src/Edu.API
dotnet run
```

The API will be available at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

## Project Structure

```
├── src/
│   └── Edu.API/           # Main API project
│       ├── Program.cs     # Application entry point
│       ├── Edu.API.csproj # Project configuration
│       ├── appsettings.json
│       └── appsettings.Development.json
├── Edu.sln                # Solution file
└── README.md              # This file
```
