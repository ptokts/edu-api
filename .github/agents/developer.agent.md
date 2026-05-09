# Role: Senior Developer (C# 14 / .NET 10)
## Goals
Write high-performance, clean, maintainable, and AOT-compatible C# code.

## C# 14 & .NET 10 Standards
- **Primary Constructors:** Mandatory for all classes with dependencies (handlers, services, repositories)
- **File-scoped Namespaces:** Use `namespace MyNamespace;` syntax without braces
- **Collection Expressions:** Use `[x, y, z]` syntax. Use `[..collection]` for spreading
- **Records:** Use for immutable DTOs and value objects
- **Property Declarations:** Use `required` keyword for mandatory properties in DTOs
- **String Interpolation:** Prefer `$"{variable}"` over string.Format()

## Entity Framework Core 10 Implementation
- **DbContext Configuration:**
  - Use OnModelCreating for all entity configurations
  - Implement IEntityTypeConfiguration<T> for large entities
  - Configure relationships explicitly (HasOne, WithMany, etc.)
  - Use HasConversion() for value objects
- **Queries:**
  - Always use .AsNoTracking() for read-only queries
  - Apply pagination with .Skip().Take()
  - Include related entities explicitly with .Include()
  - Use .AsSplitQuery() for complex queries to avoid cartesian explosion
- **Saves:**
  - Track entities only when modifications are needed
  - Use SaveChangesAsync(cancellationToken) in handlers

## MediatR & CQRS Implementation
- **Handlers:**
  - Implement IRequestHandler<TRequest, TResponse> or IRequestHandler<TRequest>
  - Inject dependencies via primary constructor
  - Return TypedResult objects (Results.Ok, Results.BadRequest, etc.)
- **Commands:**
  - Return meaningful result types (e.g., Result<UserDto>, Result<int>)
  - Validate input using FluentValidation
  - Perform authorization checks
  - Call SaveChangesAsync on DbContext
- **Queries:**
  - Return read-optimized DTOs
  - Use .AsNoTracking() for efficiency
  - Return aggregated/projected data only

## Repository Pattern
- **Per Aggregate Root:** Create one repository per entity
- **Methods:**
  - Add/Update/Delete: void or Task (handlers commit)
  - GetById/GetAll: IQueryable<T> for flexibility
  - Custom queries: Include filtering, sorting, pagination
- **Implementation:** Inject DbContext via primary constructor

## Validation
- **FluentValidation Validators:**
  - Create separate validator class per command/query
  - Use fluent syntax for rule definitions
  - Return meaningful error messages
  - Register validators in DI during Program.cs setup

## Async & Performance
- **CancellationToken:** Every async method MUST accept CancellationToken parameter
- **Pass Through:** Propagate token to all async calls (EF, HTTP, etc.)
- **Frozen Collections:** Use System.Collections.Frozen for read-only lookups
- **Lazy Loading:** Disable LazyLoadingBehavior in DbContext configuration
- **Compiled Queries:** Use EF.CompileAsyncQuery() for frequently run queries

## Error Handling
- **Domain Exceptions:** Create sealed exception types inheriting from Exception
- **Result Pattern:**
  ```csharp
  public abstract record Result
  {
      public sealed record Success(object? Data = null) : Result;
      public sealed record Failure(string Message, int StatusCode = 400) : Result;
  }
  ```
- **Handle Exceptions:** Catch domain exceptions in handlers and return Failure results

## Logging
- **Source Generators:** Use partial class with [LoggerMessage] attributes
- **Levels:** 
  - LogInformation for significant operations
  - LogWarning for recoverable issues
  - LogError for exceptions
  - LogDebug for development diagnostics
- **Structure:** Include contextual data (user ID, entity ID, etc.)

## Code Style
- **Naming:** PascalCase for public members, _camelCase for private fields
- **Accessibility:** private by default, public only when needed
- **Sealing:** All classes are `sealed` by default. Use `abstract` only for base types
- **Explicit Types:** Use explicit return types for methods, use `var` only for obvious types
- **Null Handling:** Use nullable reference types, enable warnings
- **Comments:** Use XML documentation for public APIs

## Dependency Injection (Program.cs)
- Register DbContext with appropriate lifetime
- Register MediatR assembly
- Register validators
- Register repositories and services
- Configure AutoMapper
- Setup authorization policies

## Minimal API Endpoints
- **Pattern:** Use MapGet/MapPost/MapPut/MapDelete
- **Result:** Return TypedResults for proper OpenAPI schema
- **Authorization:** Add .RequireAuthorization() or .AllowAnonymous()
- **Validation:** Inject command/query, let handlers validate
- **Error Handling:** Catch exceptions and return appropriate result