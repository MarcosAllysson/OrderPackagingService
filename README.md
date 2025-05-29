# OrderPackagingService (Desafio da loja do Manoel - L2 Code)

Projeto ASP.NET Web API para otimizar a embalagem de pedidos com base nas dimensões do produto e nas caixas disponíveis na loja do Manoel.

## Pré-requisitos

- Docker

## Setup

1. Clone este repositório:

```
git clone https://github.com/MarcosAllysson/OrderPackagingService.git
cd OrderPackagingService
```

2. Build e execute com docker-compose:

```
docker-compose up -d
```

3. Acesse a API:

```
Em: http://localhost:8080
```

## Como usar a API

1. Swagger:

```
Vá até: http://localhost:8080/swagger para ver a documentação.
```

## Autenticação:

```
1. O endpoint /api/v1/Orders/pack endpoint precisa de um token JWT.
```

```
2. Para facilitar o uso e gerar seu token, basta usar o endpoint mandando um GET em: /api/v1/Auth/generate-token no Swagger.
```

```
3. Copie apenas o retorno entre aspas e use-o no Swagger, clicando no botão "Authorize" (formato: Bearer <token>).
```

3. Exemplo de entrada para você mandar na API:

- `Apesar de que no desafio estava em português, implementei o código em inglês.`

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

4. Saída esperada pela API:

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
Verifique o serviço de health-check do banco: http://localhost:8080/health
```

## Testes:

1. Execute os testes unitários:

```
dotnet test
```

## Arquitetura que usei na API:

`Camada de .Api`: Lida com requisições e respostas HTTP, com autenticação JWT e integração com Swagger.

`Camada de .Domain`: Implementa o algoritmo de empacotamento e as regras de negócio da aplicação/API.

`Camada de .Infra`: Gerencia a persistência de dados com SQL Server e EF Core.

`Camada de .Shared`: Contém DTOs para modelos de request/response da API.

`Camada de .Tests`: Inclui testes unitários para o serviço de empacotamento.

## Segurança

`Autenticação JWT`: Protege o endpoint /api/v1/Orders/pack.

`Rate limit`: Limita as solicitações para a API em 100 requests por minuto por IP.

`CORS`: Permite solicitações entre origens para desenvolvimento.

`Cabeçalhos de Segurança`: Inclui X-Content-Type-Options, X-XSS-Protection e X-Frame-Options.

## OBS

O projeto inclui o SQL Server 2019 configurado via Docker, com migrações automáticas aplicadas na inicialização.

Embora o desafio não exija persistência, o banco de dados está pronto para salvar os resultados de empacotamento (pedidos, caixas, produtos), se necessário. Optei por não implementar persistência para focar na lógica de empacotamento e nos requisitos do desafio, mas a infraestrutura está preparada para futuras extensões.

Qualquer feedback é bem-vindo. Sou aberto sempre a aprender e melhorar.

Há muito o que melhorar. Desde já, agradeço pela oportunidade, L2.
