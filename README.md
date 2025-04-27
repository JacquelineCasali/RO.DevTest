# 🛒 API E-commerce - RO.DevTest

Projeto de API RESTful para um sistema básico de e-commerce, desenvolvido como desafio técnico utilizando .NET 8.

## 🚀 Tecnologias Utilizadas

- .NET 8.0
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- GitHub Actions (Gitflow + Commits Semânticos)
- Docker (opcional)
- Swagger (Documentação de API)

---

## ⚙️ Funcionalidades Implementadas

- CRUD completo de Clientes
- CRUD completo de Produtos
- CRUD completo de Vendas (com associação Cliente + Produtos)
- Autenticação e Autorização com JWT
- Controle de acesso baseado em roles (`Admin`, `User`)
- Paginação e Filtro em listagens (Clients, Products, Sales)
- Análise de Vendas: relatório de vendas em um período (total de vendas, receita total, receita por produto)
- Seed automático de usuário Admin
- API RESTful organizada por responsabilidades
- Paginação e filtros nos endpoints
- Relatórios de vendas



---

## 🔒 Usuário de Login Padrão (Seeded)

- **Usuário:** admin
- **Senha:** 123456
- **Role:** Admin

Após autenticar, você receberá um Token JWT para acessar os endpoints protegidos.

---

## 🛠️ Como Rodar o Projeto Localmente

1. **Clone o repositório**
```bash
git clone https://github.com/JacquelineCasali/RO.DevTest

2. **Entre na pasta **

-- cd RO.DevTest

3. **Restaure os pacotes **
dotnet restore

4. **Atualize o banco de dados** 
dotnet ef database update

5. **Execute a aplicação** 
dotnet run

6. ** Acesse no postman**


## 🗂️ Principais Endpoints

