# hacking

## Overview

**hacking** is a multi-layered .NET 8.0 solution that provides a clean architecture implementation for retrieving and serving top stories from Hacker News. The project is organized into four main layers:

- **Api**: ASP.NET Core Minimal API for exposing endpoints.
- **App**: Application logic, MediatR queries/handlers, and service orchestration.
- **Domain**: Core business abstractions and domain models.
- **Infrastructure**: External service integrations, HTTP clients, and data access.

## Project Structure

```
HackingNews.slnx
src/
  HackingNews.Api/           # ASP.NET Core Minimal API project
  HackingNews.App/           # Application layer (CQRS, MediatR, services)
  HackingNews.Domain/        # Domain abstractions and models
  HackingNews.Infrastructure/# Infrastructure (HTTP clients, factories, resources)
```

### HackingNews.Api

- Exposes endpoints for retrieving Hacker News stories.
- Uses Minimal APIs and Swagger/OpenAPI for documentation.
- Handles requests via MediatR and application queries.
- Example endpoint: `/v1/hackernews?numofstories=10`

### HackingNews.App

- Contains MediatR queries and handlers (CQRS pattern).
- Implements application services such as `BestStoriesService` and `InMemHackingNewsService`.
- Coordinates between domain abstractions and infrastructure.

### HackingNews.Domain

- Defines interfaces for services and clients (e.g., `IHackerNewsClient`, `IBestStoriesService`).
- Contains custom exceptions and core contracts.

### HackingNews.Infrastructure

- Implements HTTP clients for external APIs (e.g., `HackerNewsClient` for Hacker News API).
- Provides factories and resource base classes for extensibility.
- Handles error management and logging.

## Features

- **Best Stories Retrieval**: Fetches top stories from Hacker News using their public API.
- **In-Memory Caching**: Caches story IDs for efficient repeated access.
- **CQRS & MediatR**: Clean separation of queries and handlers.
- **Minimal API**: Lightweight, fast HTTP endpoints.
- **Extensible Architecture**: Easily add new providers or data sources.

## Getting Started

1. **Requirements**
   - .NET 8.0 SDK
   - (Optional) Docker for containerization

2. **Build and Run**

   ```sh
   dotnet build
   dotnet run --project src/HackingNews.Api/HackingNews.Api.csproj
   ```

3. **API Usage**

   - Access Swagger UI at `https://localhost:7262/swagger`
   - Example request:
     ```
     GET /v1/hackernews?numofstories=10
     Example: http://localhost:5029/v1/hackernews?numofstories=10
     ```

## Configuration

- API settings are managed in `appsettings.json` and `appsettings.Development.json`.
- The Hacker News API base URL is configured in the infrastructure layer.

## Development

- **Dependency Injection** is used throughout for service registration.
- **Unit Testing**: (Add your tests in a separate test project.)
- **Extending**: To add new providers, implement the relevant interfaces in the domain and infrastructure layers.

## License

MIT (add your license here)

---