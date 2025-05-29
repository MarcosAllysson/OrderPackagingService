# OrderPackagingService

A ASP.NET Web API for optimizing order packaging based on product dimensions and available boxes.

## Prerequisites

- Docker
- .NET 9 SDK (if you're running it locally)

## Setup

1. Clone the repository:

```
git clone https://github.com/MarcosAllysson/OrderPackagingService.git
cd OrderPackagingService
```

2. Build and run with Docker Compose:

```
docker-compose up -d
```

3. Access api:

```
At http://localhost:8080
```

## Usage

1. Swagger:

```
Navigate to http://localhost:8080/swagger for API documentation and exploration.
```

2. Authentication:

```
2.1: The /api/v1/orders/pack endpoint requires a JWT token.
2.2: To obtain a token, use the GET /api/v1/auth/generate-token endpoint in Swagger.
2.3: Copy the returned Token and use it in the Swagger "Authorize" button (format: Bearer <token>).
```

3. Health Check

```
Check the service health at http://localhost:8080/health
```

## Testing:

1. Run unit tests:

```
dotnet test
```

## API Architecture:

API Layer: Handles HTTP requests and responses, with JWT authentication and Swagger integration.

Domain Layer: Implements the packing algorithm and business rules.

Infra Layer: Manages data persistence with SQL Server and EF Core.

Shared Layer: Contains DTOs for request/response models.

Tests Layer: Includes unit tests for the packing service.

## Security Features

JWT Authentication: Protects the /api/v1/orders/pack endpoint.

Rate Limiting: Limits requests to 100 per minute per IP.

CORS: Allows cross-origin requests for development.

Security Headers: Includes X-Content-Type-Options, X-XSS-Protection, and X-Frame-Options.

## Notes

The project uses SQL Server 2019 in Docker for persistence.

Migrations are applied at startup.
