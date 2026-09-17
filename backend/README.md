<!-- Created by Ege Duyar - RentAWhip -->
# ⚙️ RentAWhip - Backend API & Core Domain Services

Designed and created by **Ege Duyar**.

This directory contains the **.NET Core Web API** and **Domain Layer Architecture** for **RentAWhip**.

For full system architecture, database setup, and detailed explanation of how RentAWhip works under the hood, see the [Master Project README](../README.md).

---

## 🏛️ Architecture Overview

The backend maintains existing clean architecture principles across decoupled modules:

- **`Core/`**: Universal cross-cutting infrastructure:
  - Security utilities (JWT Access Tokens, HMACSHA512 Hashing, Encryption helpers).
  - Generic Data Access (`EfEntityRepositoryBase<TEntity, TContext>`).
  - Aspect-Oriented Programming (Castle DynamicProxy interceptors for Cache, Performance, Logging, and Transactions).
- **`Entities/`**: Concrete domain models and Data Transfer Objects (`CarDetailDto`, `UserForLoginDto`, etc.).
- **`DataAccess/`**: Entity Framework Core DbContext (`RentAWhipDatabaseContext`) and LINQ projection queries.
- **`Business/`**: Domain managers, FluentValidation rules, Autofac module registration, and business rules (Findeks credit scoring, Rental eligibility, File management).
- **`WebAPI/`**: RESTful API Controllers (`CarsController`, `RentalsController`, `AuthController`, `CarImagesController`, etc.).
- **`ConsoleUI/`**: Command Line Interface for quick testing of service methods.

---

## 🚀 Running the Web API

```bash
cd backend/WebAPI
dotnet restore
dotnet run
```

Endpoints will be accessible at `https://localhost:44327/api/`.
