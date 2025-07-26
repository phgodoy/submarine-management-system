# 🚢 Submarine Management System (SMS)

This project was built as a study-focused application to learn and apply **CQRS** design pattern in .NET, along with **JWT authentication**, **Swagger** for API documentation, **Dockerized SQL Server**, and **unit testing** using **xUnit**.

---

## 🧠 Technologies and Concepts

- ✅ **.NET 8**
- ✅ **CQRS (Command Query Responsibility Segregation)** with **MediatR**
- ✅ **JWT Authentication**
- ✅ **Swagger** for API documentation
- ✅ **Docker** for SQL Server container
- ✅ **xUnit** for unit testing
- ✅ **AutoMapper**
- ✅ **Clean Architecture**
- ✅ **Entity Framework Core**

---

## 📁 Project Structure

The solution follows **Clean Architecture** and is structured as:

- `Sms.Domain`: Domain entities and validations  
- `Sms.Application`: Application layer (CQRS, Services, DTOs)  
- `Sms.Infra.Data`: Database repositories and EF configuration  
- `Sms.WebApi`: REST API layer  
- `Sms.Test`: Unit test project  

---

## 🔐 Authentication
- The API uses JWT authentication to protect secured endpoints. To access them:

- Log in using the provided credentials.

- Copy the returned JWT token.

- In Swagger, click "Authorize" and paste the token.

---

## 🎓 Purpose
- This project was created for educational purposes to:

- Practice and understand the CQRS pattern

- Structure code following Clean Architecture

- Learn and implement JWT authentication

- Use Swagger for interactive documentation

- Set up and run SQL Server in Docker

- Write unit tests using xUnit

---

## 🚀 Getting Started

1.Clone the repository:
   ```bash
   git clone https://github.com/your-username/sms.git
   cd sms
   ```
2.Start the SQL Server container with Docker:
   ```bash
   docker-compose up -d
   cd sms
   ```
3.Apply the migrations to the database:
   ```bash
   docker-compose up -d
   cd sms
   ```
4.Run the application:
   ```bash
   dotnet run --project Sms.WebApi
   ```
---

## 🧪 Testing
 Unit tests are written for domain logic, especially focusing on Submarine and SubmarineSystem entities.
 To run the tests:
   ```bash
    dotnet test Sms.Test
   ```
