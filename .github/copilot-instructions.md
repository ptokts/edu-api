# Global Project Context: .NET 10 Web API

This is a .NET 10 Web API project using Clean Architecture principles with MediatR for CQRS patterns.

## The Workflow

For all tasks, follow this two-phase approach:

1. **Phase 1 - Architect**: Reference `./.github/agents/architect.agent.md`
   - Define the structure, patterns, and contracts
   - List required files/folders
   - Define interface contracts
   - Describe the data flow
   - **Stop here if the task is complex and ask for confirmation**

2. **Phase 2 - Developer**: Reference `./.github/agents/developer.agent.md`
   - Write the implementation based on the Architect's plan
   - Follow C# 14 and .NET 10 standards
   - Ensure all code meets the implementation standards

## Strict Rules

- **Language & Framework**: Always use C# 14 and .NET 10
- **API Style**: Prefer Minimal APIs over Controllers
- **Architecture**: Follow Clean Architecture (Domain, Application, Infrastructure, WebApi layers)
- **Communication**: Use MediatR for CQRS (Commands/Queries)
- **Security**: Ensure all endpoints have authorization policies
- **Data**: Use Fluent API for entity configurations, not Data Annotations
- **Code Quality**: See `./.github/agents/developer.agent.md` for C# 14 standards and best practices
- **Complex Tasks**: STOP after Phase 1 and ask for confirmation before proceeding to implementation