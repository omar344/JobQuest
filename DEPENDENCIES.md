# Dependency inventory

This project centralizes package versions via [Directory.Packages.props](Directory.Packages.props). Dependencies are assigned to the project that owns the responsibility for that concern.

## Ownership by project

| Project | Package(s) | Ownership rationale |
| --- | --- | --- |
| [JobQuest.Domain/JobQuest.Domain.csproj](JobQuest.Domain/JobQuest.Domain.csproj) |  | The  domain entity inherits from , so the identity abstractions are part of the domain model. |
| [JobQuest.Api/JobQuest.Api.csproj](JobQuest.Api/JobQuest.Api.csproj) |  | Design-time tooling for EF Core migrations and scaffolding belongs in the host API project. |
| [JobQuest.Application/JobQuest.Application.csproj](JobQuest.Application/JobQuest.Application.csproj) |  | Application layer defines DI contracts and service registration abstractions. |
| [JobQuest.Infrastructure/JobQuest.Infrastructure.csproj](JobQuest.Infrastructure/JobQuest.Infrastructure.csproj) | ,  | Persistence and cryptography are infrastructure responsibilities. |
| [aspire/JobQuest.ServiceDefaults/JobQuest.ServiceDefaults.csproj](aspire/JobQuest.ServiceDefaults/JobQuest.ServiceDefaults.csproj) | , ,  | Shared startup / observability defaults are owned by the Aspire hosting layer. |

## Centralized package versions

All package versions are defined in [Directory.Packages.props](Directory.Packages.props), which keeps upgrades consistent across the solution.

### Current version map

-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 
-  → 

## Dependency rules

1. Domain projects should only carry framework dependencies that are required by the domain model itself.
2. Infrastructure owns persistence and runtime data-access providers.
3. Application owns DI contracts and use-case composition.
4. API hosts own tooling and startup dependencies that are not part of the shared runtime domain.
5. Shared platform defaults live under the Aspire project.
