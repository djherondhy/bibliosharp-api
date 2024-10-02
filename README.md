# Biblioteca API 📚

Esta é uma API desenvolvida em .NET para gerenciar uma biblioteca. A API oferece funcionalidades para autenticação de usuários, gerenciamento de clientes e livros, além de permitir que os clientes emprestem e devolvam livros.

## Funcionalidades 🚀

- **Autenticação e Login**: Utiliza tokens JWT Bearer para autenticar usuários 🔑.
- **Controle de Clientes**: Criação, leitura, atualização e exclusão de clientes 👤.
- **Controle de Livros**: Criação, leitura, atualização e exclusão de livros 📖.
- **Empréstimo de Livros**: Clientes podem emprestar livros (até 3 por vez) se estiverem disponíveis 📅.
- **Devolução de Livros**: Clientes podem devolver livros emprestados 🔄.

## Modelos 📦

- **Admin**: Representa um administrador da biblioteca 👨‍💼.
- **Cliente**: Representa um cliente que pode emprestar livros 🧑‍🎓.
- **Livro**: Representa um livro disponível na biblioteca 📚.
- **Emprestimo**: Representa o empréstimo de um livro por um cliente 🏷️.

## Estrutura da API 🛠️

- **Controladores**:
  - `AdminController`: Gerencia a autenticação e o registro de administradores 🔐.
  - `ClienteController`: Gerencia as operações relacionadas a clientes 📋.
  - `LivroController`: Gerencia as operações relacionadas a livros 📚.
  - `EmprestimoController`: Gerencia as operações de empréstimo e devolução de livros 📥.

## Tecnologias Utilizadas 🖥️

- .NET 6 ou superior
- Entity Framework Core
- JWT Bearer para autenticação

# Documentação da API de Biblioteca 📚

## Endpoints de Admin 👨‍💼

### POST /Admin/register
Adiciona um novo administrador ao sistema. 🆕

### POST /Admin/login
Realiza o login de um administrador. 🔑

---

## Endpoints de Cliente 🧑‍🎓

### POST /Cliente
Adiciona um novo cliente ao sistema. 🆕

### GET /Cliente
Obtém uma lista de todos os clientes. 📋

### GET /Cliente/{id}
Obtém os detalhes de um cliente específico pelo ID. 🔍

### PUT /Cliente/{id}
Atualiza os dados de um cliente existente. ✏️

### DELETE /Cliente/{id}
Remove um cliente existente pelo ID. ❌

---

## Endpoints de Empréstimo 📖

### POST /Emprestimo/{clienteId}/emprestar/{livroId}
Empresta um livro para um cliente. 📅

### POST /Emprestimo/devolver/{clienteId}/{livroId}
Devolve um livro emprestado por um cliente. 🔄

---

## Endpoints de Livro 📚

### POST /Livro
Adiciona um novo livro ao sistema. 🆕

### GET /Livro
Obtém uma lista de todos os livros. 📋

### GET /Livro/{id}
Obtém os detalhes de um livro específico pelo ID. 🔍

### PUT /Livro/{id}
Atualiza os dados de um livro existente. ✏️

### DELETE /Livro/{id}
Remove um livro existente pelo ID. ❌


### POST /Emprestimo/devolver/{clienteId}/{livroId}
Devolve um livro emprestado por um cliente.


