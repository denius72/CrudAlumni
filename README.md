# Currículo - Denis Côcco de Sousa

Desenvolvedor Full-Stack | Analista de Sistemas

📍 Localização: Curitiba (PR)
📧 Email: denius72@gmail.com
📞 Telefone: (41) 99912-3355

💼 LinkedIn: [denius72](https://www.linkedin.com/in/denius72/)
🐱 GitHub: [denius72](https://github.com/denius72) 

---

## Experiência

**Analista de Sistemas Júnior** - Sociedade Educacional Herrero, 2021 – 2025
- Responsável pelo setor de TI da instituição.
- Criou dashboards interativos com PowerBI para monitoramento de dados acadêmicos.
- Desenvolveu automações em Python para processos internos.
- Realizou levantamento de requisitos para novos sistemas e elaborou documentação técnica.
- Desenvolveu relatórios personalizados usando MySQL, integrando dados acadêmicos e financeiros.
- Configurou servidores AD personalizados.
- Forneceu suporte para a equipe técnico-administrativa.
- Colaborou com equipes de TI para garantir funcionamento da infraestrutura.

---

## Formação Acadêmica

**Pós-graduação - Desenvolvimento Mobile**  
Pontifícia Universidade Católica do Paraná, 2022 - 2024  

**Graduação - Ciência da Computação**  
Pontifícia Universidade Católica do Paraná, 2018 - 2021  

---

## Tecnologias

- **Mobile**: Kotlin, Java, Flutter (Dart), Swift, Firebase  
- **Back-end**: C#, ASP.NET, Spring Boot, Gradle, REST APIs
- **Banco de dados**: MySQL, SQLite, SQL Server
- **Ferramentas**: Git, GitHub, Visual Studio, PowerBI
- **Outros**: HTML, CSS, Postman, Unity, Blender, AWS, Linux

---

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
