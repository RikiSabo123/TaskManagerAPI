# TaskManager

TaskManager is an ASP.NET Core 8 Web API for managing users, categories, and tasks. The solution is split into separate projects for the API layer, business logic, data access, and shared DTOs.

## Solution Structure

- TaskManager: Web API entry point, controllers, Swagger, and dependency injection
- BLL: business logic and validation rules
- DAL: database access, Entity Framework Core context, and mapping
- DTO: shared data transfer objects

## Features

- User lookup, create, update, and delete
- Task management by user or task ID
- Category management by user
- SQL Server persistence through Entity Framework Core
- Swagger/OpenAPI in development mode

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger / Swashbuckle

## API Controllers

- api/users
- api/tasks
- api/categories

## Prerequisites

- .NET 8 SDK
- SQL Server
- A connection string named TaskManagerDb in TaskManager/appsettings.json

## Getting Started

1. Restore dependencies:

   dotnet restore TaskManager.sln

2. Update the connection string in TaskManager/appsettings.json.

3. Create or update the database schema if needed.

4. Run the API:

   dotnet run --project TaskManager/TaskManager.csproj

## Example Endpoints

- GET /api/users/GetAllUsers
- POST /api/users/login  (body: `{ "email": "...", "password": "..." }`)
- POST /api/users
- GET /api/tasks/GetTasksByUser
- POST /api/tasks
- GET /api/categories

## Notes

- Swagger is enabled in development.
- The solution currently builds successfully.
- Some controller design choices can still be improved later, but the project is now documented in a clean English README.