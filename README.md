# Users Microservice — eCommerce Solution

Part of a **3-service microservices architecture** built with **ASP.NET Core**, implementing **Clean Architecture** principles with Dapper for high-performance data access.

## 🏗️ Architecture Overview

This Users Microservice is one of three services in a distributed eCommerce system:

| Service | Responsibility | Database |
|---------|----------------|----------|
| **UsersService** *(this repo)* | User management *(JWT & registration coming soon)* | PostgreSQL |
| ProductsService | Product catalog and inventory | MySQL |
| OrdersService | Order processing and validation | MongoDB |

Other services consume this microservice via **HTTP clients** with **Polly-based fault tolerance**.

## 🛠️ Tech Stack

**Backend**
- ASP.NET Core — Minimal APIs
- Dapper — lightweight micro-ORM for high-performance queries
- Npgsql — PostgreSQL .NET driver
- FluentValidation — input validation
- AutoMapper — DTO ↔ Entity mapping

**Infrastructure**
- Docker & Docker Compose
- PostgreSQL — relational database
- Integrated with Ocelot API Gateway (from OrdersService repo)

**Frontend** *(in development)*
- Angular — UI for orders, products, users

## 📐 Project Structure (Clean Architecture)
├── ECommerceApp.Core/            # Domain entities, interfaces, business rules  
├── ECommerceApp.Infrastructure/  # Data access (Dapper), repositories, DB context  
├── ECommerceAppAPI/              # API layer, Minimal APIs, Program.cs, Dockerfile  
└── ECommerceAppSolution.UserService.sln  

## 🚀 Getting Started

Detailed setup instructions and prerequisites will follow soon. 🛠️

Project is actively under development — stay tuned.

## ✨ Key Features

- ✅ **Web API with Controllers** — traditional RESTful API design
- ✅ **Minimal APIs** — lightweight and high-performance endpoints
- ✅ **Dapper** — raw SQL performance with object mapping
- ✅ **PostgreSQL** via Npgsql driver
- ✅ **FluentValidation** for request validation
- ✅ **AutoMapper profiles** for DTO mappings
- ✅ **Containerized** with Docker for consistent deployment

## 🔮 Roadmap

- [ ] JWT authentication & token generation
- [ ] User registration & password hashing (BCrypt)
- [ ] Role-based authorization
- [ ] Refresh token mechanism
- [ ] Unit tests (xUnit + Moq)
- [ ] Angular frontend (in development)
- [ ] Azure deployment

## Learning Project

Built while working through ".NET Microservices with Azure DevOps & AKS | Basic to Master"(https://www.udemy.com/course/dot-net-microservices-ecommerce-project-azure-devops-kubernetes-aks/learn/lecture/45853823?start=1#overview) by Harsha Vardhan on Udemy.

## 👨‍💻 Author

**Akshat Parasher** — Software Engineer | C#/.NET Developer | Germany 🇩🇪

- 🔗 [Portfolio](https://akshat95-portfolio.netlify.app)
- 🔗 [GitHub](https://github.com/AkshatAspNetCore)
- 🔗 [GitLab](https://gitlab.com/arkhamknight95-group)
