# 🥩 MeatOrderSystem

Uma aplicação para gerenciamento de carnes, compradores e pedidos. Desenvolvido com .NET 8 (backend RESTful) e SQL Server.

---

## 🔧 Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (API Docs)
- AwesomeAPI (cotação de moedas)

---

## 🧱 Arquitetura

O projeto é estruturado em 4 camadas principais:

```
MeatOrderSystem/
├── MeatOrderSystem.API           → Camada de apresentação (Web API)
├── MeatOrderSystem.Application   → Camada de auxiliares (DTOs)
├── MeatOrderSystem.Controller    → Camada de apresentação (API)
├── MeatOrderSystem.Service       → Regras de negócio (services)
├── MeatOrderSystem.Data          → Persistência de dados (repositórios + DbContext)
└── MeatOrderSystem.Model         → Entidades de domínio (Models/Entities)
```

---

## ⚙️ Como rodar localmente

### 1. Clonar o repositório

```bash
git clone https://github.com/PauloMachine/MeatOrderSystem.git
cd MeatOrderSystem
```

### 2. Ajustar conexão com o banco

No arquivo: `MeatOrderSystem.API/appsettings.json`, configure sua connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MeatOrderSystem;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 3. Rodar a API

```bash
dotnet run --project MeatOrderSystem.API
```

Acesse:  
📍 http://localhost:5000/swagger

## 🪙 Conversão de Moedas

A API usa a [AwesomeAPI](https://docs.awesomeapi.com.br/api-de-moedas) para conversão em tempo real de USD e EUR para BRL nos pedidos.

---

## 🧑‍💻 Autor

Feito por Paulo Santiago 💻
