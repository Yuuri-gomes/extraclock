# ExtraClock - Sistema de Ponto

## 🚀 Como Rodar o Projeto

### Pré-requisitos

- **.NET 9.0 SDK** instalado
- **Docker e Docker Compose** instalados

### Passo a Passo

1️⃣ **Clone o repositório:**

```sh
git clone https://github.com/{{seu-usuario}}/extraclock.git
cd extraclock
```

2️⃣ **Instale o Docker:**
Caso ainda não tenha o Docker instalado, siga as instruções para seu sistema operacional:

- [Docker para Windows](https://docs.docker.com/desktop/install/windows-install/)
- [Docker para Linux](https://docs.docker.com/desktop/install/linux-install/)
- [Docker para Mac](https://docs.docker.com/desktop/install/mac-install/)

3️⃣ **Suba os serviços via Docker Compose:**

```sh
docker compose up -d
```

4️⃣ **Execute o projeto:**

```sh
dotnet run
```

A API estará disponível em: `http://localhost:5016`

---

## Documentação API

Base URL da API:

```
http://localhost:5016/api/v1/overtime
```

---

## 📌 Endpoints Disponíveis

### 1️⃣ **Registrar Hora Extra**

**Endpoint:**

```
POST /api/v1/overtime/register
```

**Descrição:** Registra uma nova entrada de hora extra para um usuário.

**Exemplo de Requisição:**

```sh
curl -X POST "http://localhost:5016/api/v1/overtime/register" \
     -H "Content-Type: application/json" \
     -d '{
           "User": "yuri.gomes",
           "InitialTime": "2025-02-03 18:00:00",
           "FinishTime": "2025-02-03 23:00:00",
           "Description": "Mock description test"
         }'
```

**Exemplo de Resposta (201 Created):**

```json
{
  "id": "e44143ab-e2b8-4092-a14f-5913151b2552",
  "message": "Registered successful overtime !"
}
```

**Possíveis Códigos de Resposta:**
| Status Code | Significado |
|------------|------------|
| 201 Created | Registro criado com sucesso ! |
| 400 Bad Request | Campo faltando ou valor inválido no payload |
| 500 Internal Server Error | Internal Server Error |

---

### 2️⃣ **Listar Horas Extras de um Usuário**

**Endpoint:**

```
GET /api/v1/overtime/list?user={user.name}
```

**Descrição:** Retorna a lista de horas extras registradas para um usuário específico.

**Exemplo de Requisição:**

```sh
curl -X GET "http://localhost:5016/api/v1/overtime/list?user=yuri.gomes"
```

**Exemplo de Resposta (200 OK):**

```json
[
  {
    "id": "e44143ab-e2b8-4092-a14f-5913151b2552",
    "user": "yuri.gomes",
    "initialTime": "2025-02-03T22:00:00Z",
    "finishTime": "2025-02-04T03:00:00Z",
    "description": "mock description test",
    "date": "2025-02-04T03:24:17.476Z"
  }
]
```

**Possíveis Códigos de Resposta:**
| Status Code | Significado |
|------------|------------|
| 200 OK | Lista retornada com sucesso |
| 400 Bad Request | Parâmetro de usuário ausente ou inválido |
| 404 Not Found | Nenhum registro encontrado para o usuário informado |
| 500 Internal Server Error | Erro inesperado ao processar a requisição |

---

## 📖 Visão Geral

O **ExtraClock** é um sistema de gerenciamento de horas extras desenvolvido com .NET, utilizando uma abordagem baseada em **CQRS** e **MediatR** para garantir separação de responsabilidades, escalabilidade e flexibilidade no crescimento da aplicação.

## 🔍 Decisões Arquiteturais

### 1. **Separação de Responsabilidades**

O projeto foi estruturado seguindo princípios de **Clean Architecture**, garantindo que cada camada tenha uma responsabilidade bem definida:

- **Camada de Aplicação (Application):** Contém os casos de uso (handlers CQRS) e regras de negócio.
- **Camada de Infraestrutura (Infrastructure):** Responsável pela comunicação com bancos de dados e serviços externos.
- **Camada de Apresentação (Controllers):** Expõe a API para interação com os clientes.
- **Camada de Domínio (Domain):** Define as entidades e regras de negócio essenciais.

### 2. **Uso de CQRS (Command Query Responsibility Segregation)**

O CQRS foi adotado para separar operações de leitura (Queries) e escrita (Commands), evitando que regras de negócio de atualização afetem consultas de dados. Isso proporciona:

- Melhor organização do código.
- Maior escalabilidade e facilidade de manutenção.
- Redução de conflitos ao realizar operações simultâneas de leitura e escrita.

### 3. **Implementação do MediatR**

O MediatR é utilizado como **mediador entre os controllers e a lógica de negócio**, garantindo um código mais desacoplado e testável. Com ele:

- **Os controllers atuam apenas como pontos de entrada**, sem conter lógica de negócios diretamente.
- **Os handlers processam comandos e consultas**, garantindo que cada operação tenha um único ponto de execução.
- **Eventos podem ser publicados e assinados de maneira desacoplada**, permitindo futuras expansões como envio de notificações ou integração com outros sistemas.

## 🚀 Justificativa para o uso de CQRS e MediatR

### 📌 Por que CQRS?

- **Melhora a escalabilidade:** Permite otimizar as consultas sem impactar as operações de escrita.
- **Organização clara:** Facilita a manutenção e entendimento do código, separando responsabilidades.
- **Flexibilidade para mudanças futuras:** Podemos escalar leitura e escrita de forma independente.

### 📌 Por que MediatR?

- **Redução de acoplamento:** Controllers não precisam conhecer diretamente a lógica de negócio.
- **Facilidade de testes:** Os handlers podem ser testados isoladamente sem precisar da API.
- **Expansibilidade:** Permite adicionar novas funcionalidades (exemplo: eventos assíncronos) sem modificar a lógica principal.

## 🛠️ Tecnologias Utilizadas

- **.NET 9.0**
- **MediatR** para gerenciamento de comandos e eventos
- **Entity Framework Core** para persistência de dados
- **MongoDB.Driver** para integração com banco NoSQL
