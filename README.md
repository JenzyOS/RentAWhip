# 🚗 RentAWhip - Full-Stack Car Rental & Fleet Management Platform

[![Creator](https://img.shields.io/badge/Creator-Ege%20Duyar-007ACC?style=for-the-badge)](https://github.com/)
[![.NET Core](https://img.shields.io/badge/.NET-5.0%2B-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Angular](https://img.shields.io/badge/Angular-11.x-DD0031?style=for-the-badge&logo=angular)](https://angular.io/)
[![MSSQL](https://img.shields.io/badge/MSSQL-Server-CC292B?style=for-the-badge&logo=microsoftsqlserver)](https://www.microsoft.com/sql-server)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%2FOnion-007ACC?style=for-the-badge)](https://microservices.io/)
[![Security](https://img.shields.io/badge/Security-JWT%20%2B%20AOP-green?style=for-the-badge)](https://jwt.io/)

**RentAWhip** is an enterprise-grade, high-performance Full-Stack Car Rental & Fleet Management Application designed and maintained by **Ege Duyar**. The system is built using a decoupled **Clean/Onion Architecture backend** (.NET Web API in C#) and a responsive **Angular Single Page Application (SPA) frontend**.

---

## 💡 How RentAWhip Works Under The Hood

RentAWhip coordinates multiple distributed layers and business engines to deliver a seamless car rental experience. Below is a detailed technical walkthrough of how the core workflows operate across the system:

```
[ Angular SPA Frontend ] <--- HTTP REST API (JSON / JWT) ---> [ .NET Core Web API Backend ]
       │                                                                  │
       ├── RxJS Services & HTTP Interceptors                              ├── WebAPI Controllers
       ├── Reactive Forms & Search Pipes                                  ├── Autofac IoC & AOP Aspects
       └── LocalStorage Token & Card Vault                                ├── Business Managers & Rules Engine
                                                                          ├── Entity Framework Core & MSSQL
                                                                          └── Image File System Storage
```

### 1. 🔐 Security & JWT Authentication Flow
1. **User Registration / Login**: The user inputs credentials via `LoginComponent` or `RegisterComponent`.
2. **Password Hashing**: The request reaches `AuthManager`. Passwords are password-hashed using `HMACSHA512` with unique salts generated via `HashingHelper`. Raw passwords are **never** stored in plain text.
3. **Token Generation**: Upon successful verification, `JwtHelper` generates a signed JSON Web Token (JWT) containing user claims and expiration timestamps.
4. **Session Persistence**: The token is sent to the Angular client and saved in browser storage via `LocalStorageService`.
5. **Request Authorization**: Subsequent API calls append the JWT header. On the server side, `[SecuredOperation]` interceptors automatically validate user claims before granting execution rights to protected methods.

---

### 2. 🚘 Vehicle Catalog & Dynamic Query Pipeline
1. **Frontend Request**: `CarComponent` invokes `CarService.getCarDetails()`.
2. **LINQ Relational Projection**: In `EfCarDal`, Entity Framework Core executes an optimized LINQ SQL JOIN query uniting `Cars`, `Brands`, `Colors`, and `CarImages`.
3. **DTO Mapping**: Query output is projected directly into a clean `CarDetailDto` payload containing `CarName`, `BrandName`, `ColorName`, `DailyPrice`, `MinFindeksScore`, and image URLs.
4. **Client-Side Filtering**: Angular pipes (`BrandFilterPipe`, `ColorFilterPipe`, `CarFilterPipe`) perform instant real-time filtering without requiring additional server round-trips.

---

### 3. 📊 Findeks Credit Score Engine
1. **Minimum Credit Requirement**: Each vehicle listed in RentAWhip has a defined `MinFindeksScore` (range 0–1900).
2. **Credit Verification**: When a customer initiates a rental booking via `RentAddComponent`, `RentalManager` invokes the `FindeksService`.
3. **Validation Rule**: The system evaluates:
   ```
   Customer Credit Score >= Vehicle Minimum Findeks Score
   ```
4. **Rule Enforcement**: If the customer's score is insufficient, the transaction is rejected instantly with an alert notification.

---

### 4. 📅 Conflict-Free Rental & Overlap Validation Engine
1. **Rental Eligibility Check**: Before approving any rental, `RentalManager.Add()` queries the database for existing active rentals for the target vehicle.
2. **Date Range Collision**: A vehicle is deemed unavailable if:
   - It is currently rented and has not yet been returned (`ReturnDate == null`).
   - The requested `RentDate` and `ReturnDate` overlap with any existing rental schedule.
3. **Approval**: Only when no date collisions are detected does the system allow the booking to proceed to payment.

---

### 5. 🖼️ GUID Image Processing Engine
1. **File Upload**: Images uploaded via `CarImagesController` are passed to `FileHelper`.
2. **GUID Storage**: Files are saved on disk using auto-generated `GUID` filenames to prevent filename collisions and security vulnerabilities.
3. **Business Rule Guard**: `CarImageManager` enforces a business rule capping each vehicle at a maximum of **5 images**.
4. **Default Thumbnail Fallback**: If a vehicle has zero uploaded images, `CarImageManager` dynamically serves a default fallback company logo.

---

### 6. 💳 Mock Payment Gateway & Card Vaulting
1. **Transaction Settlement**: `PaymentComponent` collects credit card details and dispatches them to `PaymentManager`, which simulates financial clearing with a bank provider.
2. **Card Vaulting**: Upon successful payment, users are prompted to save their card for future checkouts. If confirmed, encrypted card metadata is safely stored via `LocalStorageService` for rapid one-click future rentals.

---

### 7. ⚡ Aspect-Oriented Programming (AOP) Interceptors
Cross-cutting concerns are modularized using **Castle DynamicProxy** and applied directly via attributes:

- `[SecuredOperation("car.add,admin")]`: Restricts execution to authorized claims.
- `[ValidationAspect(typeof(CarValidator))]`: Validates inputs via FluentValidation before executing business logic.
- `[CacheAspect]` / `[CacheRemoveAspect]`: Caches API responses in memory and clears cache on data mutation.
- `[PerformanceAspect(interval: 5)]`: Measures execution duration and logs performance warnings if a method takes longer than 5 seconds.
- `[LogAspect(typeof(FileLogger))]`: Asynchronously logs execution parameters to formatted disk log files.
- `[TransactionScopeAspect]`: Wraps DB operations in an atomic transaction, rolling back automatically on error.

---

## 🏛️ System Architecture & Folder Layout

```
📁 RentAWhip Workspace
 ├── 📁 backend/                --> .NET Core Web API (Clean / Onion Architecture)
 │    ├── 📁 Business/          --> Managers, Business Rules, Validation, AOP Aspects, Autofac Modules
 │    ├── 📁 Core/              --> Cross-Cutting Concerns, Security (JWT/Hashing), Generic EF Repository
 │    ├── 📁 DataAccess/        --> EF Core DB Context, Mappings, LINQ Projections & DTO Joins
 │    ├── 📁 Entities/          --> Domain Entities, DTOs (CarDetailDto, UserForLoginDto, etc.)
 │    ├── 📁 WebAPI/            --> RESTful Controllers, Middleware, AppSettings
 │    └── 📁 ConsoleUI/         --> Test CLI
 └── 📁 frontend/               --> Angular 11 SPA Application
      └── 📁 src/app/
           ├── 📁 components/   --> UI Pages (Cars, Brands, Colors, Rentals, Payment, Auth)
           ├── 📁 models/       --> TypeScript Interfaces
           ├── 📁 services/     --> API Services, LocalStorage, Auth & Payment Handlers
           └── 📁 pipes/        --> Dynamic Filter Pipes
```

---

## 🔌 API Endpoint Directory

| Method | Endpoint | Description | Authentication |
| :--- | :--- | :--- | :---: |
| `GET` | `/api/cars/getall` | Retrieve all vehicles | Public |
| `GET` | `/api/cars/getcardetails` | Fetch vehicles with joined Brand, Color & Image details | Public |
| `GET` | `/api/cars/getbyid?id={id}` | Retrieve specific car by ID | Public |
| `POST` | `/api/cars/add` | Add a new vehicle to fleet | Protected |
| `POST` | `/api/cars/update` | Update vehicle details | Protected |
| `POST` | `/api/cars/delete` | Remove vehicle from fleet | Protected |
| `GET` | `/api/brands/getall` | List vehicle manufacturers | Public |
| `GET` | `/api/colors/getall` | List vehicle colors | Public |
| `GET` | `/api/rentals/getall` | List rental records | Public |
| `POST` | `/api/rentals/add` | Create new rental (runs Findeks & date validation) | Protected |
| `POST` | `/api/carimages/add` | Upload vehicle image (GUID storage) | Protected |
| `POST` | `/api/auth/login` | Authenticate user & receive JWT token | Public |
| `POST` | `/api/auth/register` | Register new user account | Public |

---

## 🗄️ Database Setup (MSSQL)

1. Open **SQL Server Management Studio (SSMS)** or Azure Data Studio.
2. Create a new database named `RentAWhipDatabase`.
3. Open and execute the provided script file:
   ```path
   backend/RentAWhipDatabaseMsSql.sql
   ```
4. Verify the database tables (`Cars`, `Brands`, `Colors`, `Rentals`, `Customers`, `Users`, `OperationClaims`, `UserOperationClaims`, `CarImages`).
5. Update your connection string in `backend/WebAPI/appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=RentAWhipDatabase;Trusted_Connection=True;"
   }
   ```

---

## 🚀 How to Run RentAWhip

### Prerequisites
- [.NET 5.0+ SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) & [Angular CLI](https://cli.angular.io/) (`npm install -g @angular/cli@11`)
- [SQL Server](https://www.microsoft.com/sql-server)

### Running Backend API
```bash
cd backend/WebAPI
dotnet restore
dotnet run
```
> Server runs at `https://localhost:44327/api/`.

### Running Frontend Angular App
```bash
cd frontend
npm install
ng serve --open
```
> App runs at `http://localhost:4200/`.

---

## 👨‍💻 Creator & Maintainer

**RentAWhip** is designed, maintained, and created by **Ege Duyar**.
