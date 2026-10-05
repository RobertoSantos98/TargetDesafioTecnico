# Target Desafio Técnico - Módulo Comercial ERP 🚀

![.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
![Docker](https://img.shields.io/badge/Docker-Enabled-2496ED?style=for-the-badge&logo=docker)
![xUnit](https://img.shields.io/badge/Tests-xUnit-15822C?style=for-the-badge)
![Swagger](https://img.shields.io/badge/OpenAPI-Swagger-85EA2D?style=for-the-badge&logo=swagger)

Solução desenvolvida para o desafio técnico do módulo comercial ERP. A aplicação consiste em uma Web API RESTful construída com C# e .NET 8, conteinerizada com Docker e coberta por testes unitários com xUnit.

---

## 📌 Funcionalidades Desenvolvidas

1. **Cálculo de Comissões (`ComissaoService`):**
   - Agrupamento de vendas por vendedor.
   - Aplicação de alíquotas regressivas por item de venda:
     - Vendas $<$ R$ 100,00: **0%**
     - Vendas entre R$ 100,00 e R$ 499,99: **1%**
     - Vendas $\ge$ R$ 500,00: **5%**

2. **Gestão e Movimentação de Estoque (`EstoqueService`):**
   - Controle de entradas e saídas de mercadorias.
   - Identificador único (`Guid`) para cada transação.
   - Bloqueio de movimentações que resultem em saldo negativo.
   - Estado gerenciado em memória (*Singleton*) com controle de concorrência (`lock`).

3. **Cálculo de Juros por Atraso (`JurosService`):**
   - Cálculo de juros simples diários de **2,5% ao dia**.
   - Truncamento de horário (utilizando apenas a componente `.Date`).
   - Resiliência para pagamentos no prazo ou em datas futuras (retornando R$ 0,00 de juros sem lançar exceção).

---

## 🛠️ Tecnologias e Arquitetura

- **Linguagem / Framework:** C# / .NET 8.0 ASP.NET Core Web API
- **Arquitetura:** Clean Architecture / DDD simplificado em camadas (`Api`, `Application`, `Tests`)
- **Testes Unitários:** xUnit + FluentAssertions
- **Conteinerização:** Docker + Docker Compose
- **Documentação de API:** OpenAPI / Swagger UI

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado e rodando **OU** [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

### Opção 1: Executando via Docker Compose (Recomendado)

1. Clone o repositório:
   ```bash
   git clone [https://github.com/SeuUsuario/TargetDesafioTecnico.git](https://github.com/SeuUsuario/TargetDesafioTecnico.git)
   cd TargetDesafioTecnico
   ```

2. Suba o container com o Docker Compose:
   ```bash
   docker compose up -d --build
   ```

3. Acesse a documentação do Swagger no navegador:
   - **http://localhost:8080/swagger**

---

### Opção 2: Executando localmente via .NET CLI

1. Restaure as dependências e compile o projeto:
   ```bash
   dotnet restore
   dotnet build
   ```

2. Execute a API:
   ```bash
   dotnet run --project TargetDesafioTecnico.Api
   ```

3. Acesse a URL informada no terminal (geralmente `https://localhost:7123/swagger`).

---

## 🧪 Executando os Testes Unitários

Para rodar a suíte de testes xUnit e verificar a cobertura do projeto:

```bash
dotnet test --logger "console;verbosity=detailed"
```

---

## 📍 Endpoints da API

| Método | Endpoint | Descrição |
| :--- | :--- | :--- |
| `POST` | `/api/Comissao/calcular` | Processa a lista de vendas e calcula a comissão por vendedor |
| `GET` | `/api/Estoque` | Lista os produtos e seus saldos atuais |
| `POST` | `/api/Estoque/movimentar` | Registra entrada ou saída de estoque |
| `POST` | `/api/Juros/calcular` | Calcula os juros por atraso a partir da data de vencimento |

---

## 🤝 Autor

Desenvolvido por **Roberto Santos**.
- GitHub: [@RobertoSantos98](https://github.com/RobertoSantos98)
