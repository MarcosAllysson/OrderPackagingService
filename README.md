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

## Access service

1. Endpoint:

```
Access the API at http://localhost:8080/api/v1/orders/pack
```

2. Test project with Swagger

```
Access at at http://localhost:8080/swagger
```

## Testing

1. Run tests

```
dotnet test
```

## Security

1. Authentication

```
The /api/v1/orders/pack endpoint requires a JWT token. Use the Swagger UI to authenticate.
```
