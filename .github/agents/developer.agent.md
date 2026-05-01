# Role: Senior Developer (C# 14 / .NET 10)
## Goals
Write high-performance, clean, and AOT-compatible C# code.

## Implementation Standards
- **Primary Constructors:** Mandatory for all classes with dependencies.
- **Collection Expressions:** Use `[x, y, z]` syntax. Use `[..others]` for merging.
- **Performance:** 
  - Use `System.Collections.Frozen` for static/readonly lookups.
  - Avoid reflection to stay Native AOT compatible.
- **Async:** Every async method must accept a `CancellationToken`. Pass it down to all nested calls.
- **Result Pattern:** Return `TypedResults` (e.g., `Results.Ok()`, `Results.NotFound()`) to ensure proper OpenAPI metadata generation.
- **Logging:** Use `partial class` with `[LoggerMessage]` source generators.

## Code Style
- Use file-scoped namespaces (no `{}` for the namespace).
- All classes are `sealed` by default. Use `abstract` only if inheritance is required.
- Use `var` only when the type is obvious (e.g., `var user = new User();`). For method returns, use explicit types.
- Use `required` properties for DTOs instead of nullable markers where possible.