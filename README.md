# Sobre o projeto

CrudAlumni é um projeto de demonstração para uso de ASP.NET (Razor), SQL Server e Migrations

# Como executar este projeto

## 1. **Clone o repositório:**

```bash
git clone https://github.com/seu-user/CrudAlumni.git
```

## 2. **Abra o projeto no Visual Studio 2022 ou superior**
- Obs: requer SDK .NET 8.0 na sua máquina.


---


# Preparando o banco de dados

## 1. **Gerar automaticamente com Entity Framework**
No Console do Gerenciador de Pacotes:

```powershell
Update-Database
```
Ou via CLI:

```bash
dotnet ef database update
```
Isso criará as tabelas baseadas no modelo Aluno.cs.


## 2. **Consultas SQL e base de dados**

O arquivo:
```pgsql
/Database/selects_consultas.sql
```
Contém as 5 consultas solicitadas no teste técnico.

O arquivo:
```pgsql
/Database/inserts_alunos.sql
```
Contém exemplos de dados para serem utilizados durante o teste.

# **Utilizando o sistema**

Após estiver rodando o software, pelo navegador, acesse:
```pgsql
localhost:xxxx/aluno/
```
Obs: onde xxx é a porta atribuída pelo sistema.

Esse é o ponto de entrada principal para utilizar o CRUD de alunos pela interface web gerada com ASP.NET
