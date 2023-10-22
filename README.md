# GoCook API

A API GoCook é um sistema de gerenciamento de receitas e usuários, construído em C# utilizando ASP.NET Core e Entity Framework para interagir com um banco de dados SQL Server.

## Funcionalidades

- Cadastro e autenticação de usuários.
- Criação, edição e exclusão de receitas.

## Configuração

### Banco de Dados

A API utiliza um banco de dados SQL Server. Para configurar a conexão, edite a string de conexão no arquivo `appsettings.json`.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=seu_servidor;Database=GoCook;Trusted_Connection=True;"
}
```
## Executando a Aplicação

1. **Clone o repositório.**
   ```bash
   git clone [https://github.com/JuliaOliveiraa/GoCook-API](https://github.com/JuliaOliveiraa/GoCook-API.git)https://github.com/JuliaOliveiraa/GoCook-API.git
   ```
2. **Abra o projeto no Visual Studio ou no Visual Studio Code.**

3. **Configure a string de conexão do banco de dados.**
   Edite o arquivo appsettings.json e substitua a string de conexão conforme necessário.
