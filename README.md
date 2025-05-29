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
2.1: The /api/v1/Orders/pack endpoint requires a JWT token.
2.2: To obtain a token, use the GET /api/v1/Auth/generate-token endpoint in Swagger.
2.3: Copy the returned Token and use it in the Swagger "Authorize" button (format: Bearer <token>).
```

3. Input example:

```
[
  {
    "orderId": 1,
    "products": [
      {
        "productId": "PS5",
        "dimensions": {
          "height": 40,
          "width": 10,
          "length": 25
        }
      },
      {
        "productId": "Volante",
        "dimensions": {
          "height": 40,
          "width": 30,
          "length": 30
        }
      }
    ]
  },
  {
    "orderId": 2,
    "products": [
      {
        "productId": "Joystick",
        "dimensions": {
          "height": 15,
          "width": 20,
          "length": 10
        }
      },
      {
        "productId": "Fifa 24",
        "dimensions": {
          "height": 10,
          "width": 30,
          "length": 10
        }
      },
      {
        "productId": "Call of Duty",
        "dimensions": {
          "height": 30,
          "width": 15,
          "length": 10
        }
      }
    ]
  },
  {
    "orderId": 3,
    "products": [
      {
        "productId": "Headset",
        "dimensions": {
          "height": 25,
          "width": 15,
          "length": 20
        }
      }
    ]
  },
  {
    "orderId": 4,
    "products": [
      {
        "productId": "Mouse Gamer",
        "dimensions": {
          "height": 5,
          "width": 8,
          "length": 12
        }
      },
      {
        "productId": "Teclado Mecânico",
        "dimensions": {
          "height": 4,
          "width": 45,
          "length": 15
        }
      }
    ]
  },
  {
    "orderId": 5,
    "products": [
      {
        "productId": "Cadeira Gamer",
        "dimensions": {
          "height": 120,
          "width": 60,
          "length": 70
        }
      }
    ]
  },
  {
    "orderId": 6,
    "products": [
      {
        "productId": "Webcam",
        "dimensions": {
          "height": 7,
          "width": 10,
          "length": 5
        }
      },
      {
        "productId": "Microfone",
        "dimensions": {
          "height": 25,
          "width": 10,
          "length": 10
        }
      },
      {
        "productId": "Monitor",
        "dimensions": {
          "height": 50,
          "width": 60,
          "length": 20
        }
      },
      {
        "productId": "Notebook",
        "dimensions": {
          "height": 2,
          "width": 35,
          "length": 25
        }
      }
    ]
  },
  {
    "orderId": 7,
    "products": [
      {
        "productId": "Jogo de Cabos",
        "dimensions": {
          "height": 5,
          "width": 15,
          "length": 10
        }
      }
    ]
  },
  {
    "orderId": 8,
    "products": [
      {
        "productId": "Controle Xbox",
        "dimensions": {
          "height": 10,
          "width": 15,
          "length": 10
        }
      },
      {
        "productId": "Carregador",
        "dimensions": {
          "height": 3,
          "width": 8,
          "length": 8
        }
      }
    ]
  },
  {
    "orderId": 9,
    "products": [
      {
        "productId": "Tablet",
        "dimensions": {
          "height": 1,
          "width": 25,
          "length": 17
        }
      }
    ]
  },
  {
    "orderId": 10,
    "products": [
      {
        "productId": "HD Externo",
        "dimensions": {
          "height": 2,
          "width": 8,
          "length": 12
        }
      },
      {
        "productId": "Pendrive",
        "dimensions": {
          "height": 1,
          "width": 2,
          "length": 5
        }
      }
    ]
  }
]
```

4. Output expected:

```
[
  {
    "orderId": 1,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Volante",
          "PS5"
        ]
      }
    ]
  },
  {
    "orderId": 2,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Call of Duty",
          "Fifa 24",
          "Joystick"
        ]
      }
    ]
  },
  {
    "orderId": 3,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Headset"
        ]
      }
    ]
  },
  {
    "orderId": 4,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Teclado Mecânico",
          "Mouse Gamer"
        ]
      }
    ]
  },
  {
    "orderId": 5,
    "boxes": [
      {
        "boxId": null,
        "observation": "Produto não cabe em nenhuma caixa disponível.",
        "products": [
          "Cadeira Gamer"
        ]
      }
    ]
  },
  {
    "orderId": 6,
    "boxes": [
      {
        "boxId": "Caixa 2",
        "observation": null,
        "products": [
          "Monitor",
          "Webcam",
          "Notebook",
          "Microfone"
        ]
      }
    ]
  },
  {
    "orderId": 7,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Jogo de Cabos"
        ]
      }
    ]
  },
  {
    "orderId": 8,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Controle Xbox",
          "Carregador"
        ]
      }
    ]
  },
  {
    "orderId": 9,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "Tablet"
        ]
      }
    ]
  },
  {
    "orderId": 10,
    "boxes": [
      {
        "boxId": "Caixa 1",
        "observation": null,
        "products": [
          "HD Externo",
          "Pendrive"
        ]
      }
    ]
  }
]
```

## Health Check

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

The project includes a SQL Server 2019 configured via Docker, with automatic migrations applied at startup.

Although the challenge does not require persistence, the database is ready to save the packaging results (orders, boxes, products) if necessary. I chose not to implement persistence to focus on the packaging logic and explicit requirements, but the infrastructure is prepared for future extensions.
