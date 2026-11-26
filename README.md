# JobQuest

JobQuest is a platform that connects freelancers with clients to collaborate on job opportunities. This repository contains the backend API.

> Status: under active development. The solution structure, domain model, and infrastructure are in place; API endpoints are being built.

## Tech Stack

- **.NET 10** / ASP.NET Core
- **Entity Framework Core** with **SQL Server 2022** (Docker)
- **ASP.NET Core Identity** for authentication and user management
- **.NET Aspire** for local orchestration and observability defaults
- **Central Package Management** via `Directory.Packages.props` (see [DEPENDENCIES.md](DEPENDENCIES.md))

## Architecture

Clean Architecture with strict layer separation:

```
JobQuest.sln
├── JobQuest.Api/            # Composition root and HTTP layer
├── JobQuest.Application/    # DTOs, interfaces, use-case contracts, DI registration
├── JobQuest.Domain/         # Entities, enums, and domain model (no infrastructure concerns)
├── JobQuest.Infrastructure/ # EF Core persistence, repositories, service implementations
└── aspire/
    ├── JobQuest.AppHost/          # .NET Aspire orchestration host
    └── JobQuest.ServiceDefaults/  # Shared startup and observability defaults
```

## Domain Model

- **Users**: `ApplicationUser` (ASP.NET Core Identity), `Client`, `Freelancer`, `Skill`
- **Marketplace**: `Job`, `Proposal`, `Contract`, `Payment`
- **Lifecycle enums**: `JobStatus`, `JobCategoryEnum`, `ProposalStatus`, `ContractStatus`, `PaymentStatus`

## Getting Started

### Prerequisites

- .NET 10 SDK
- Docker Desktop (for SQL Server)

### Database

Start SQL Server in Docker:

```bash
docker compose up -d
```

This runs SQL Server 2022 (Developer edition) on port **1434** with a persistent volume. Set the `MSSQL_SA_PASSWORD` environment variable before starting.

### Run

```bash
dotnet run --project JobQuest.Api
```

or through the Aspire AppHost for the full orchestrated experience:

```bash
dotnet run --project aspire/JobQuest.AppHost
```

## Roadmap

- [ ] REST endpoints for jobs, proposals, contracts, and payments
- [ ] Authentication and authorization flows
- [ ] Application-layer services and validation

## License

See [LICENSE](LICENSE).
