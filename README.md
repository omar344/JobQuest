# JobQuest

JobQuest is a .NET backend solution for the JobQuest platform.

## Solution structure

- `JobQuest.Api` — API host
- `JobQuest.Application` — application services
- `JobQuest.Domain` — domain model
- `JobQuest.Infrastructure` — infrastructure
- `aspire/JobQuest.ServiceDefaults` — Aspire defaults
- `aspire/JobQuest.AppHost` — app host

## Architecture

- Domain owns core business logic
- Application owns use cases
- Infrastructure owns EF Core and integrations
- API exposes the application over HTTP

## Package management

Package versions are centralized through `Directory.Packages.props`. See [DEPENDENCIES.md](DEPENDENCIES.md).

## Local setup

```bash
dotnet restore
dotnet build JobQuest.sln -nologo
```

## Contributing

Contributions are welcome and should stay aligned with the layered architecture.
