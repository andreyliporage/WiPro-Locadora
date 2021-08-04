# API Locadora

A API permite cadastrar um filme, listar filmes, cadastrar cliente, listar clientes, locar um filme e devolver o filme.


### Banco de Dados Utilizado:
 - EntityFramework In Memory.

---

## Métodos disponíveis:

### Criar usuário
Método: `POST` <br>
Endpoint: `localhost:5001/api/clientes` <br>
Retorno: `Retorna o objeto criado` <br>
JSON:
```json
{
	"nome": "Andrey",
	"cpf": "12378345771"
}
```
---

### Listar usuário
Método: `GET` <br>
Endpoint: `localhost:5001/api/clientes` <br>
Retorno: `Retorna uma listagem com todos os usuários` <br>
JSON:
```json
[
  {
    "nome": "Sthefane",
    "cpf": "12378345771",
    "locacaoId": "4febd1c4-78b7-4138-8f21-bc0fbccb7685",
    "locacao": {
      "clienteId": "25901171-5fb8-4865-a1e9-833a86a30679",
      "filmes": [
        {
          "nome": "Teste Filme Post 1",
          "genero": "Suspense",
          "disponivel": false,
          "locacaoId": "4febd1c4-78b7-4138-8f21-bc0fbccb7685",
          "id": "1df62309-96ee-494d-9e8f-558657c1fbe4"
        }
      ],
      "diaLocao": "2021-08-04T21:21:33.2705874Z",
      "devolucao": "2021-08-07T21:21:33.2705874Z",
      "id": "4febd1c4-78b7-4138-8f21-bc0fbccb7685"
    },
    "id": "25901171-5fb8-4865-a1e9-833a86a30679"
  }
]
```
---

### Criar filme
Método: `POST` <br>
Endpoint: `localhost:5001/api/filmes/` <br>
Retorno: `Retorna o objeto criado` <br>
JSON:
```json
{
  "nome": "Teste Filme Post 1",
  "genero": "Suspense",
  "disponivel": true,
  "locacaoId": "00000000-0000-0000-0000-000000000000",
  "id": "1df62309-96ee-494d-9e8f-558657c1fbe4"
}
```

---

### Listar filmes
Método: `GET` <br>
Endpoint: `localhost:5001/api/filmes/` <br>
Retorno: `Retorna uma listagem com todos os filmes` <br>
JSON:
```json
[
  {
    "nome": "Teste Filme Post 1",
    "genero": "Suspense",
    "disponivel": true,
    "locacaoId": "00000000-0000-0000-0000-000000000000",
    "id": "ab7f3350-12a2-4e89-bcf8-0e9fcc1c42e1"
  },
  {
    "nome": "Teste Filme Post 2",
    "genero": "Suspense",
    "disponivel": true,
    "locacaoId": "00000000-0000-0000-0000-000000000000",
    "id": "80d3e831-7fda-44f6-89cb-547dc8483292"
  }
]
```

---

### Criar locação
Método: `POST` <br>
Enpoint: `localhost:5001/api/locacoes/` <br>
Retorno: `Retorna o objeto criado` <br>
JSON:
```json
{
  "clienteId": "25901171-5fb8-4865-a1e9-833a86a30679",
  "filmes": [
    {
      "nome": "Teste Filme Post 1",
      "genero": "Suspense",
      "disponivel": false,
      "locacaoId": "4febd1c4-78b7-4138-8f21-bc0fbccb7685",
      "id": "1df62309-96ee-494d-9e8f-558657c1fbe4"
    }
  ],
  "diaLocao": "2021-08-04T21:21:33.2705874Z",
  "devolucao": "2021-08-07T21:21:33.2705874Z",
  "id": "4febd1c4-78b7-4138-8f21-bc0fbccb7685"
}
```
---

### Listar locações
Método: `GET` <br>
Enpoint: `localhost:5001/api/locacoes/` <br>
Retorno: `Retorna uma listagem com todas as locações` <br>
JSON:
```json
[
  {
    "clienteId": "25901171-5fb8-4865-a1e9-833a86a30679",
    "filmes": [
      {
        "nome": "Teste Filme Post 1",
        "genero": "Suspense",
        "disponivel": false,
        "locacaoId": "4febd1c4-78b7-4138-8f21-bc0fbccb7685",
        "id": "1df62309-96ee-494d-9e8f-558657c1fbe4"
      }
    ],
    "diaLocao": "2021-08-04T21:21:33.2705874Z",
    "devolucao": "2021-08-07T21:21:33.2705874Z",
    "id": "4febd1c4-78b7-4138-8f21-bc0fbccb7685"
  },
  {
    "clienteId": "4862b9a0-0376-4a2c-9992-604492ccf1aa",
    "filmes": [
      {
        "nome": "Teste Filme Post 2",
        "genero": "Ação",
        "disponivel": false,
        "locacaoId": "3108347a-fa96-4701-a74b-6540b46749d2",
        "id": "6226c504-f6f7-427f-adf3-0659c7887939"
      }
    ],
    "diaLocao": "2021-08-04T21:30:21.1122146Z",
    "devolucao": "2021-08-07T21:30:21.1122146Z",
    "id": "3108347a-fa96-4701-a74b-6540b46749d2"
  }
]
```
---

### Devolução de filmes
Método: `PUT` <br>
Enpoint: `localhost:5001/api/locacoes?idCliente` <br>
QueryParams: `Id do cliente` <br>
Retorno: `204 NO CONTENT`