# 🎬 Movie Rental Management System API

A comprehensive .NET Core 8 Web API built with **Clean Architecture** principles, demonstrating best practices in modern API development. This learning project includes CRUD operations, Entity Framework Core, AutoMapper, Fluent Validation, Dependency Injection, and structured logging.

## 📋 Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Tech Stack](#tech-stack)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Database Setup](#database-setup)
- [Running the Application](#running-the-application)
- [API Documentation](#api-documentation)
- [Project Architecture](#project-architecture)
- [File Organization](#file-organization)
- [Sample API Requests](#sample-api-requests)
- [Database Schema](#database-schema)
- [Logging](#logging)
- [Middleware](#middleware)
- [Validation](#validation)
- [Error Handling](#error-handling)
- [Future Enhancements](#future-enhancements)
- [Troubleshooting](#troubleshooting)

---

## ✨ Features

### Core Functionality
- ✅ **Complete CRUD Operations** for 3 entities (Movies, Customers, Rentals)
- ✅ **Clean Architecture** with separated layers (Core, Application, Infrastructure, Presentation)
- ✅ **Repository Pattern** for data access abstraction
- ✅ **Dependency Injection** for loose coupling and testability
- ✅ **AutoMapper** for seamless DTO to Entity mapping

### Validation & Data Quality
- ✅ **Fluent Validation** with custom validation rules
- ✅ **Data Annotations** on entities for database constraints
- ✅ **Input validation** at controller and service layers
- ✅ **Exception Handling Middleware** for centralized error management

### Database & Persistence
- ✅ **Entity Framework Core** with SQL Server
- ✅ **Database Relationships** (One-to-Many, Foreign Keys)
- ✅ **Indexes** for query performance optimization
- ✅ **Timestamp columns** for audit tracking

### Logging & Monitoring
- ✅ **Serilog** logging framework with file and console output
- ✅ **Structured logging** with contextual information
- ✅ **Request/Response logging middleware**
- ✅ **Rolling file logs** with daily rotation

### API Standards
- ✅ **RESTful endpoints** following best practices
- ✅ **HTTP Status Codes** (200, 201, 204, 400, 404, 500)
- ✅ **Swagger/OpenAPI** documentation
- ✅ **CORS** support for cross-origin requests
- ✅ **Response DTOs** for clean API contracts

---

## 🏗️ Project Structure

```
MovieRentalAPI/
├── src/
│   ├── Core/                          # Domain layer
│   │   ├── Entities/
│   │   │   ├── Movie.cs
│   │   │   ├── Customer.cs
│   │   │   └── Rental.cs
│   │   ├── Exceptions/
│   │   └── Constants/
│   │
│   ├── Application/                   # Application layer
│   │   ├── DTOs/
│   │   │   ├── MovieCreateDto.cs
│   │   │   ├── MovieUpdateDto.cs
│   │   │   ├── MovieReadDto.cs
│   │   │   ├── CustomerCreateDto.cs
│   │   │   ├── CustomerUpdateDto.cs
│   │   │   ├── CustomerReadDto.cs
│   │   │   ├── RentalCreateDto.cs
│   │   │   ├── RentalUpdateDto.cs
│   │   │   └── RentalReadDto.cs
│   │   ├── Mappers/
│   │   │   └── MappingProfile.cs
│   │   ├── Services/
│   │   │   ├── IMovieService.cs
│   │   │   ├── MovieService.cs
│   │   │   ├── ICustomerService.cs
│   │   │   ├── CustomerService.cs
│   │   │   ├── IRentalService.cs
│   │   │   └── RentalService.cs
│   │   └── Validators/
│   │       ├── MovieValidator.cs
│   │       ├── CustomerValidator.cs
│   │       └── RentalValidator.cs
│   │
│   ├── Infrastructure/                # Infrastructure layer
│   │   ├── Data/
│   │   │   └── MovieRentalDbContext.cs
│   │   ├── Repositories/
│   │   │   ├── IGenericRepository.cs
│   │   │   ├── GenericRepository.cs
│   │   │   ├── IMovieRepository.cs
│   │   │   ├── MovieRepository.cs
│   │   │   ├── ICustomerRepository.cs
│   │   │   ├── CustomerRepository.cs
│   │   │   ├── IRentalRepository.cs
│   │   │   └── RentalRepository.cs
│   │   └── Logging/
│   │
│   ├── Presentation/                  # Presentation layer
│   │   ├── Controllers/
│   │   │   ├── MoviesController.cs
│   │   │   ├── CustomersController.cs
│   │   │   └── RentalsController.cs
│   │   ├── Middleware/
│   │   │   ├── ExceptionHandlingMiddleware.cs
│   │   │   └── LoggingMiddleware.cs
│   │   └── Extensions/
│   │       └── ServiceCollectionExtensions.cs
│   │
│   └── appsettings.json
│
├── Program.cs
├── MovieRentalAPI.csproj
├── README.md
└── SQL Script/
    └── MovieRentalDB_Script.sql
```

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| .NET | 8.0 | Runtime Framework |
| ASP.NET Core | 8.0 | Web API Framework |
| Entity Framework Core | 8.0 | ORM |
| SQL Server | 2019+ | Database |
| AutoMapper | 12.0+ | Object Mapping |
| FluentValidation | 11.3+ | Data Validation |
| Serilog | 3.1+ | Structured Logging |
| Swagger/OpenAPI | 6.0+ | API Documentation |

---

## 📦 Prerequisites

Before you begin, ensure you have the following installed:

### Required Software
- ✅ **.NET SDK 8.0** or later ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- ✅ **SQL Server 2019** or later (Express, Developer, or full version)
- ✅ **SQL Server Management Studio (SSMS)** ([Download](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms))
- ✅ **Visual Studio 2022** or **Visual Studio Code** with C# extension
- ✅ **Git** (optional, for version control)

### System Requirements
- OS: Windows 10/11, Linux, or macOS
- RAM: 4GB minimum (8GB recommended)
- Storage: 2GB free space

### Knowledge Required
- Basic C# programming
- RESTful API concepts
- SQL basics
- Understanding of Dependency Injection

---

## 🚀 Installation & Setup

### Step 1: Create a New Project

```bash
# Using .NET CLI
dotnet new webapi -n MovieRentalAPI
cd MovieRentalAPI
```

### Step 2: Install NuGet Packages

```bash
# Entity Framework Core
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# AutoMapper
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# Fluent Validation
dotnet add package FluentValidation.AspNetCore

# Serilog
dotnet add package Serilog
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

### Step 3: Create the Directory Structure

```bash
mkdir -p src/Core/Entities
mkdir -p src/Core/Exceptions
mkdir -p src/Core/Constants
mkdir -p src/Application/DTOs
mkdir -p src/Application/Mappers
mkdir -p src/Application/Services
mkdir -p src/Application/Validators
mkdir -p src/Infrastructure/Data
mkdir -p src/Infrastructure/Repositories
mkdir -p src/Infrastructure/Logging
mkdir -p src/Presentation/Controllers
mkdir -p src/Presentation/Middleware
mkdir -p src/Presentation/Extensions
```

### Step 4: Copy All Project Files

Copy each file from the sections above (Entities, DTOs, Services, etc.) into their respective directories.

---

## ⚙️ Configuration

### Update Connection String

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=MovieRentalDB;Trusted_Connection=true;Encrypt=false;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "AllowedHosts": "*",
  "Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console"
      },
      {
        "Name": "File",
        "Args": {
          "path": "logs/log-.txt",
          "rollingInterval": "Day",
          "outputTemplate": "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
        }
      }
    ]
  }
}
```

### Connection String Examples

**Windows Authentication:**
```
Server=DESKTOP-ABC123;Database=MovieRentalDB;Trusted_Connection=true;Encrypt=false;
```

**SQL Authentication:**
```
Server=localhost,1433;Database=MovieRentalDB;User Id=sa;Password=YourPassword;Encrypt=false;
```

**Local Default Instance:**
```
Server=(localdb)\mssqllocaldb;Database=MovieRentalDB;Trusted_Connection=true;Encrypt=false;
```

**Azure SQL Database:**
```
Server=servername.database.windows.net;Database=MovieRentalDB;User Id=username;Password=password;
```

---

## 🗄️ Database Setup

### Option 1: Using SQL Script (Recommended for Learning)

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. Open the file `MovieRentalDB_Script.sql`
4. Execute the script (F5 or Execute button)
5. Database and sample data will be created automatically

### Option 2: Using Entity Framework Migrations

```bash
# In Package Manager Console
# Make sure you're in the project root directory

# Add Migration
Add-Migration InitialCreate

# Update Database
Update-Database
```

### Verify Database Creation

```sql
-- Run in SSMS
USE MovieRentalDB;
GO

SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES;
GO

-- Should display: Movies, Customers, Rentals
```

---

## ▶️ Running the Application

### Using Visual Studio

1. Open `MovieRentalAPI.csproj` in Visual Studio 2022
2. Set breakpoints if needed (optional)
3. Press **F5** or click **Start Debug**
4. Application launches at `https://localhost:7001`

### Using Visual Studio Code

```bash
# Terminal
dotnet run
```

### Using Command Line

```bash
# Build the project
dotnet build

# Run the application
dotnet run

# Run with specific configuration
dotnet run --configuration Release
```

### Expected Output

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

---

## 📚 API Documentation

### Access Swagger UI

Once the application is running:
- Navigate to: `https://localhost:7001/swagger`
- You'll see interactive API documentation
- Test endpoints directly from the browser

---

## 🎯 API Endpoints

### Movies Endpoints

| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| GET | `/api/movies/{id}` | Get movie by ID | 200, 404 |
| GET | `/api/movies` | Get all movies | 200 |
| POST | `/api/movies` | Create new movie | 201, 400 |
| PUT | `/api/movies` | Update movie | 200, 400, 404 |
| DELETE | `/api/movies/{id}` | Delete movie | 204, 404 |
| GET | `/api/movies/genre/{genre}` | Get movies by genre | 200 |
| GET | `/api/movies/available/all` | Get available movies | 200 |

### Customers Endpoints

| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| GET | `/api/customers/{id}` | Get customer by ID | 200, 404 |
| GET | `/api/customers` | Get all customers | 200 |
| POST | `/api/customers` | Create new customer | 201, 400 |
| PUT | `/api/customers` | Update customer | 200, 400, 404 |
| DELETE | `/api/customers/{id}` | Delete customer | 204, 404 |
| GET | `/api/customers/email/{email}` | Get customer by email | 200, 404 |
| GET | `/api/customers/active/all` | Get active customers | 200 |

### Rentals Endpoints

| Method | Endpoint | Description | Status |
|--------|----------|-------------|--------|
| GET | `/api/rentals/{id}` | Get rental by ID | 200, 404 |
| GET | `/api/rentals` | Get all rentals | 200 |
| POST | `/api/rentals` | Create new rental | 201, 400 |
| PUT | `/api/rentals` | Update rental | 200, 400, 404 |
| DELETE | `/api/rentals/{id}` | Delete rental | 204, 404 |
| GET | `/api/rentals/customer/{customerId}` | Get rentals by customer | 200 |
| GET | `/api/rentals/overdue/all` | Get overdue rentals | 200 |
| GET | `/api/rentals/active/all` | Get active rentals | 200 |

---

## 🏛️ Project Architecture

### Clean Architecture Layers

#### 1. **Core Layer** (Domain)
- **Purpose**: Contains business entities and rules
- **Contents**: 
  - Entities (Movie, Customer, Rental)
  - Data annotations and validation rules
  - No external dependencies
- **Independence**: Doesn't depend on any other layer

```
Core/
├── Entities/
│   ├── Movie.cs (Movie entity with properties)
│   ├── Customer.cs (Customer entity)
│   └── Rental.cs (Rental entity)
└── Exceptions/
    └── Custom exceptions (if needed)
```

#### 2. **Application Layer** (Use Cases)
- **Purpose**: Orchestrates business logic and data transformation
- **Contents**:
  - DTOs (Data Transfer Objects)
  - Services (business logic)
  - Validators (FluentValidation rules)
  - AutoMapper profiles
- **Dependencies**: Depends only on Core layer

```
Application/
├── DTOs/ (Input/Output contracts)
├── Services/ (Business logic)
├── Validators/ (Fluent validation rules)
└── Mappers/ (AutoMapper configuration)
```

#### 3. **Infrastructure Layer** (External Concerns)
- **Purpose**: Handles data persistence, external services, logging
- **Contents**:
  - DbContext (EF Core)
  - Repository implementations
  - Logging setup
  - Database migrations
- **Dependencies**: Depends on Core and Application layers

```
Infrastructure/
├── Data/ (DbContext, migrations)
├── Repositories/ (Data access)
└── Logging/ (Serilog setup)
```

#### 4. **Presentation Layer** (API)
- **Purpose**: Exposes API endpoints and handles HTTP concerns
- **Contents**:
  - Controllers
  - Middleware
  - Dependency injection setup
  - Program.cs configuration
- **Dependencies**: Depends on all layers

```
Presentation/
├── Controllers/ (API endpoints)
├── Middleware/ (Exception handling, logging)
└── Extensions/ (Service registration)
```

### Data Flow

```
HTTP Request
    ↓
Controller (Presentation)
    ↓
Service (Application) - Business Logic
    ↓
Repository (Infrastructure) - Data Access
    ↓
DbContext (Infrastructure) - EF Core
    ↓
SQL Server (Database)
    ↓
DbContext (Infrastructure)
    ↓
Repository (Infrastructure)
    ↓
Service (Application)
    ↓
Controller (Presentation)
    ↓
HTTP Response
```

---

## 📁 File Organization

### DTOs (Data Transfer Objects)

**Purpose**: Define the shape of data exchanged with clients

```
Application/DTOs/
├── MovieCreateDto.cs      ← For POST requests
├── MovieUpdateDto.cs      ← For PUT requests
├── MovieReadDto.cs        ← For GET responses
├── CustomerCreateDto.cs   ← For POST requests
├── CustomerUpdateDto.cs   ← For PUT requests
├── CustomerReadDto.cs     ← For GET responses
├── RentalCreateDto.cs     ← For POST requests
├── RentalUpdateDto.cs     ← For PUT requests
└── RentalReadDto.cs       ← For GET responses
```

### Services

**Purpose**: Contain business logic and orchestrate operations

```
Application/Services/
├── IMovieService.cs       ← Interface (contract)
├── MovieService.cs        ← Implementation
├── ICustomerService.cs    ← Interface
├── CustomerService.cs     ← Implementation
├── IRentalService.cs      ← Interface
└── RentalService.cs       ← Implementation
```

### Repositories

**Purpose**: Provide data access abstraction

```
Infrastructure/Repositories/
├── IGenericRepository.cs  ← Generic interface (CRUD)
├── GenericRepository.cs   ← Generic implementation
├── IMovieRepository.cs    ← Movie-specific interface
├── MovieRepository.cs     ← Movie-specific implementation
├── ICustomerRepository.cs ← Customer-specific interface
├── CustomerRepository.cs  ← Customer-specific implementation
├── IRentalRepository.cs   ← Rental-specific interface
└── RentalRepository.cs    ← Rental-specific implementation
```

### Controllers

**Purpose**: Handle HTTP requests and return responses

```
Presentation/Controllers/
├── MoviesController.cs    ← Movies endpoints
├── CustomersController.cs ← Customers endpoints
└── RentalsController.cs   ← Rentals endpoints
```

---

## 💡 Sample API Requests

### Create a Movie (POST)

**Request:**
```bash
curl -X POST https://localhost:7001/api/movies \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Avatar",
    "description": "A marine on an alien planet",
    "releaseYear": 2009,
    "genre": "Science Fiction",
    "durationInMinutes": 162,
    "rentalPrice": 5.99,
    "availableStock": 10
  }'
```

**Response (201 Created):**
```json
{
  "movieId": 13,
  "title": "Avatar",
  "description": "A marine on an alien planet",
  "releaseYear": 2009,
  "genre": "Science Fiction",
  "durationInMinutes": 162,
  "rentalPrice": 5.99,
  "availableStock": 10,
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T10:30:00Z"
}
```

### Get All Movies (GET)

**Request:**
```bash
curl https://localhost:7001/api/movies
```

**Response (200 OK):**
```json
[
  {
    "movieId": 1,
    "title": "The Shawshank Redemption",
    "description": "Two imprisoned men bond over the years...",
    "releaseYear": 1994,
    "genre": "Drama",
    "durationInMinutes": 142,
    "rentalPrice": 4.99,
    "availableStock": 8,
    "createdAt": "2024-01-15T08:00:00Z",
    "updatedAt": "2024-01-15T08:00:00Z"
  },
  {
    "movieId": 2,
    "title": "The Dark Knight",
    "description": "When the menace known as Joker...",
    "releaseYear": 2008,
    "genre": "Action",
    "durationInMinutes": 152,
    "rentalPrice": 5.99,
    "availableStock": 6,
    "createdAt": "2024-01-15T08:00:00Z",
    "updatedAt": "2024-01-15T08:00:00Z"
  }
]
```

### Create a Customer (POST)

**Request:**
```bash
curl -X POST https://localhost:7001/api/customers \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Alice",
    "lastName": "Johnson",
    "email": "alice.johnson@email.com",
    "phoneNumber": "+1234567800",
    "address": "999 Hollywood Boulevard",
    "city": "Los Angeles",
    "postalCode": "90028",
    "country": "United States",
    "membershipFee": 9.99
  }'
```

**Response (201 Created):**
```json
{
  "customerId": 11,
  "firstName": "Alice",
  "lastName": "Johnson",
  "email": "alice.johnson@email.com",
  "phoneNumber": "+1234567800",
  "address": "999 Hollywood Boulevard",
  "city": "Los Angeles",
  "postalCode": "90028",
  "country": "United States",
  "membershipFee": 9.99,
  "isActive": true,
  "membershipDate": "2024-01-15T10:30:00Z",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T10:30:00Z"
}
```

### Create a Rental (POST)

**Request:**
```bash
curl -X POST https://localhost:7001/api/rentals \
  -H "Content-Type: application/json" \
  -d '{
    "customerId": 1,
    "movieId": 3,
    "dueDate": "2024-01-22T23:59:59Z"
  }'
```

**Response (201 Created):**
```json
{
  "rentalId": 21,
  "customerId": 1,
  "movieId": 3,
  "rentalDate": "2024-01-15T10:30:00Z",
  "dueDate": "2024-01-22T23:59:59Z",
  "returnDate": null,
  "rentalPrice": 5.99,
  "lateFee": 0.00,
  "status": "Active",
  "createdAt": "2024-01-15T10:30:00Z",
  "updatedAt": "2024-01-15T10:30:00Z"
}
```

### Get Overdue Rentals (GET)

**Request:**
```bash
curl https://localhost:7001/api/rentals/overdue/all
```

**Response (200 OK):**
```json
[
  {
    "rentalId": 4,
    "customerId": 2,
    "movieId": 2,
    "rentalDate": "2024-01-08T10:30:00Z",
    "dueDate": "2024-01-14T23:59:59Z",
    "returnDate": null,
    "rentalPrice": 5.99,
    "lateFee": 0.00,
    "status": "Overdue",
    "createdAt": "2024-01-08T10:30:00Z",
    "updatedAt": "2024-01-15T10:30:00Z"
  }
]
```

### Update a Movie (PUT)

**Request:**
```bash
curl -X PUT https://localhost:7001/api/movies \
  -H "Content-Type: application/json" \
  -d '{
    "movieId": 1,
    "title": "The Shawshank Redemption - Remastered",
    "description": "Two imprisoned men bond over the years...",
    "releaseYear": 1994,
    "genre": "Drama",
    "durationInMinutes": 142,
    "rentalPrice": 5.99,
    "availableStock": 10
  }'
```

**Response (200 OK):**
```json
{
  "movieId": 1,
  "title": "The Shawshank Redemption - Remastered",
  "description": "Two imprisoned men bond over the years...",
  "releaseYear": 1994,
  "genre": "Drama",
  "durationInMinutes": 142,
  "rentalPrice": 5.99,
  "availableStock": 10,
  "createdAt": "2024-01-15T08:00:00Z",
  "updatedAt": "2024-01-15T11:00:00Z"
}
```

### Delete a Movie (DELETE)

**Request:**
```bash
curl -X DELETE https://localhost:7001/api/movies/13
```

**Response (204 No Content):**
```
(Empty response body)
```

### Error Response (400 Bad Request)

**Request:**
```bash
curl -X POST https://localhost:7001/api/movies \
  -H "Content-Type: application/json" \
  -d '{
    "title": "A",
    "description": "Too short",
    "releaseYear": 1800
  }'
```

**Response (400 Bad Request):**
```json
{
  "errors": {
    "Title": [
      "Title must be between 3 and 200 characters"
    ],
    "Description": [
      "Description must be between 10 and 1000 characters"
    ],
    "ReleaseYear": [
      "Release year must be between 1900 and 2024"
    ]
  }
}
```

---

## 🗂️ Database Schema

### Movies Table

| Column | Type | Constraints | Notes |
|--------|------|-------------|-------|
| MovieId | INT | PK, Identity | Primary key |
| Title | NVARCHAR(200) | NOT NULL, Index | Movie title |
| Description | NVARCHAR(1000) | NOT NULL | Full description |
| ReleaseYear | INT | NOT NULL, Index | Year movie was released |
| Genre | NVARCHAR(50) | NOT NULL, Index | Genre category |
| DurationInMinutes | INT | NOT NULL | Movie length |
| RentalPrice | DECIMAL(10,2) | NOT NULL | Rental cost |
| AvailableStock | INT | NOT NULL | Number available |
| RowVersion | ROWVERSION | NOT NULL | Concurrency control |
| CreatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Creation timestamp |
| UpdatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Last update timestamp |

### Customers Table

| Column | Type | Constraints | Notes |
|--------|------|-------------|-------|
| CustomerId | INT | PK, Identity | Primary key |
| FirstName | NVARCHAR(100) | NOT NULL | Customer first name |
| LastName | NVARCHAR(100) | NOT NULL | Customer last name |
| Email | NVARCHAR(255) | NOT NULL, Unique, Index | Email address |
| PhoneNumber | NVARCHAR(20) | NOT NULL | Contact number |
| Address | NVARCHAR(500) | NOT NULL | Street address |
| City | NVARCHAR(100) | NOT NULL | City |
| PostalCode | NVARCHAR(20) | NOT NULL | ZIP/Postal code |
| Country | NVARCHAR(100) | NOT NULL | Country |
| MembershipFee | DECIMAL(10,2) | NOT NULL, Default: 0 | Annual fee |
| IsActive | BIT | NOT NULL, Default: 1, Index | Active status |
| MembershipDate | DATETIME | NOT NULL, Default: GETUTCDATE() | Join date |
| CreatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Creation timestamp |
| UpdatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Last update timestamp |

### Rentals Table

| Column | Type | Constraints | Notes |
|--------|------|-------------|-------|
| RentalId | INT | PK, Identity | Primary key |
| CustomerId | INT | NOT NULL, FK, Index | References Customers |
| MovieId | INT | NOT NULL, FK, Index | References Movies |
| RentalDate | DATETIME | NOT NULL, Default: GETUTCDATE() | Rental date |
| DueDate | DATETIME | NOT NULL, Index | Return due date |
| ReturnDate | DATETIME | NULL | Actual return date |
| RentalPrice | DECIMAL(10,2) | NOT NULL | Price charged |
| LateFee | DECIMAL(10,2) | NOT NULL, Default: 0 | Late return fee |
| Status | NVARCHAR(20) | NOT NULL, Default: 'Active', Index | Active/Returned/Overdue |
| CreatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Creation timestamp |
| UpdatedAt | DATETIME | NOT NULL, Default: GETUTCDATE() | Last update timestamp |

### Relationships

```
Customers (1) ──── (Many) Rentals
                      │
Movies (1) ──────── (Many) Rentals
```

- **ON DELETE CASCADE**: Deleting a customer or movie also deletes related rentals

---

## 📝 Logging

### Logging Configuration

Serilog is configured in `Program.cs` and `appsettings.json`:

```csharp
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
```

### Log Levels

| Level | Usage | Example |
|-------|-------|---------|
| **Verbose** | Detailed diagnostic info | Variable values, timing |
| **Debug** | Debug-level info | Parameter details |
| **Information** | General operational info | Request received, operation completed |
| **Warning** | Warning messages | Resource not found, low stock |
| **Error** | Error events | Exception occurred |
| **Fatal** | Critical errors | Application crash |

### Log Files Location

```
Your Project Root/
└── logs/
    ├── log-20240115.txt
    ├── log-20240116.txt
    └── log-20240117.txt
```

### Sample Log Output

```
2024-01-15 10:30:45.123 +01:00 [INF] HTTP Request: GET /api/movies
2024-01-15 10:30:45.456 +01:00 [INF] Fetching all movies
2024-01-15 10:30:45.789 +01:00 [INF] HTTP Response: 200 for /api/movies
2024-01-15 10:31:00.100 +01:00 [INF] POST request to create movie: Avatar
2024-01-15 10:31:00.450 +01:00 [INF] Creating new movie: Avatar
2024-01-15 10:31:00.789 +01:00 [INF] Movie created successfully with ID: 13
```

---

## 🔧 Middleware

### ExceptionHandlingMiddleware

**Purpose**: Centralized exception handling for all unhandled exceptions

**Location**: `Presentation/Middleware/ExceptionHandlingMiddleware.cs`

**Features**:
- Catches all unhandled exceptions
- Returns appropriate HTTP status codes
- Logs exceptions with context
- Returns structured error responses

**Example Response**:
```json
{
  "message": "An error occurred while processing your request",
  "detail": "An item with the same key has already been added. Key: Email"
}
```

### LoggingMiddleware

**Purpose**: Log all HTTP requests and responses

**Location**: `Presentation/Middleware/LoggingMiddleware.cs`

**Features**:
- Logs HTTP method and path for each request
- Logs response status code
- Captures timing information
- Integrates with Serilog

**Example Logs**:
```
HTTP Request: POST /api/customers
HTTP Response: 201 for /api/customers
HTTP Request: GET /api/rentals/overdue/all
HTTP Response: 200 for /api/rentals/overdue/all
```

---

## ✅ Validation

### Fluent Validation

Custom validation rules ensure data integrity:

**Movie Validation** (`MovieValidator.cs`):
```csharp
RuleFor(x => x.Title)
    .NotEmpty().WithMessage("Title is required")
    .Length(3, 200).WithMessage("Title must be between 3 and 200 characters");

RuleFor(x => x.ReleaseYear)
    .InclusiveBetween(1900, DateTime.Now.Year)
    .WithMessage($"Release year must be between 1900 and {DateTime.Now.Year}");
```

**Customer Validation** (`CustomerValidator.cs`):
```csharp
RuleFor(x => x.Email)
    .NotEmpty().WithMessage("Email is required")
    .EmailAddress().WithMessage("Invalid email address format");

RuleFor(x => x.PhoneNumber)
    .Matches(@"^\+?[1-9]\d{1,14}$")
    .WithMessage("Invalid phone number format");
```

**Rental Validation** (`RentalValidator.cs`):
```csharp
RuleFor(x => x.DueDate)
    .GreaterThan(DateTime.UtcNow)
    .WithMessage("Due date must be in the future");
```

### Data Annotations

Entity models use `System.ComponentModel.DataAnnotations` for constraints:

```csharp
[Required(ErrorMessage = "Title is required")]
[StringLength(200, MinimumLength = 3)]
public string Title { get; set; }

[EmailAddress(ErrorMessage = "Invalid email address")]
public string Email { get; set; }

[Range(0.01, 100)]
public decimal RentalPrice { get; set; }
```

---

## ⚠️ Error Handling

### HTTP Status Codes Used

| Code | Meaning | Example |
|------|---------|---------|
| **200** | OK | Request successful, data returned |
| **201** | Created | Resource created successfully |
| **204** | No Content | Deletion successful |
| **400** | Bad Request | Validation failed or invalid data |
| **404** | Not Found | Resource doesn't exist |
| **500** | Internal Server Error | Unhandled exception |

### Error Response Format

**Validation Error (400)**:
```json
{
  "errors": {
    "Title": [
      "Title must be between 3 and 200 characters"
    ],
    "RentalPrice": [
      "Rental price must be greater than 0"
    ]
  }
}
```

**Not Found Error (404)**:
```json
{
  "message": "Movie with ID 999 not found"
}
```

**Server Error (500)**:
```json
{
  "message": "An error occurred while processing your request",
  "detail": "Exception details here"
}
```

---

## 🚀 Future Enhancements

### Phase 2: Authentication & Security
- [ ] JWT (JSON Web Tokens) authentication
- [ ] Role-based access control (Admin, Customer, Manager)
- [ ] User registration and login endpoints
- [ ] Password hashing (BCrypt)
- [ ] Refresh token mechanism

### Phase 3: Advanced Features
- [ ] Search and filtering with `IQueryable`
- [ ] Pagination (skip/take)
- [ ] Sorting by multiple columns
- [ ] Advanced filtering (date range, price range)
- [ ] Text search across multiple fields

### Phase 4: Business Logic
- [ ] Overdue rental handling with automatic fee calculation
- [ ] Movie recommendation system
- [ ] Customer rating and reviews
- [ ] Reservation system for unavailable movies
- [ ] Promotional codes and discounts

### Phase 5: API Enhancements
- [ ] API versioning (v1, v2)
- [ ] Rate limiting to prevent abuse
- [ ] Caching (Redis, in-memory)
- [ ] Response compression
- [ ] API key authentication

### Phase 6: Monitoring & Analytics
- [ ] Health check endpoints
- [ ] Metrics collection (response times, error rates)
- [ ] Application Insights integration
- [ ] Performance monitoring
- [ ] Usage analytics

### Phase 7: Testing
- [ ] Unit tests (Xunit, Moq)
- [ ] Integration tests
- [ ] API endpoint tests
- [ ] Validation tests
- [ ] Repository tests

### Phase 8: DevOps & Deployment
- [ ] Docker containerization
- [ ] Docker Compose for local development
- [ ] CI/CD pipeline (GitHub Actions, Azure DevOps)
- [ ] Automated testing in CI/CD
- [ ] Cloud deployment (Azure App Service)
- [ ] Database backup strategy
- [ ] Disaster recovery plan

---

## 🔧 Troubleshooting

### Issue 1: Connection String Error

**Error**: `Cannot connect to database`

**Solution**:
```bash
# Verify SQL Server is running
# Update connection string in appsettings.json
# Test connection string format
# Make sure database name matches

# Example correct format:
Server=DESKTOP-ABC123;Database=MovieRentalDB;Trusted_Connection=true;Encrypt=false;
```

### Issue 2: Migration Errors

**Error**: `The entity type 'Movie' requires a primary key to be defined`

**Solution**:
```bash
# Ensure DbSet is configured in DbContext
# Check all entities have [Key] attribute
# Run Update-Database with correct context

# In Package Manager Console:
Update-Database -Verbose
```

### Issue 3: Port Already in Use

**Error**: `Address already in use on port 7001`

**Solution**:
```bash
# Find process using port 7001
netstat -ano | findstr :7001

# Kill process (example: PID 12345)
taskkill /PID 12345 /F

# Or specify different port in launchSettings.json
```

### Issue 4: CORS Errors

**Error**: `Access to XMLHttpRequest blocked by CORS policy`

**Solution**:
```csharp
// In Program.cs, ensure CORS is configured
services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

app.UseCors("AllowAll");
```

### Issue 5: Entity Framework Not Finding Migrations

**Error**: `Could not find a DbContext in the project`

**Solution**:
```bash
# Install Entity Framework Tools
dotnet tool install --global dotnet-ef

# Specify startup project in Package Manager Console
Update-Database -StartupProject MovieRentalAPI
```

### Issue 6: Validation Errors Not Showing

**Error**: `FluentValidation rules not being executed`

**Solution**:
```csharp
// In Program.cs, ensure FluentValidation is registered
services.AddValidatorsFromAssemblyContaining<MovieCreateValidator>();

// And in AddControllers
.AddFluentValidation()
```

### Issue 7: Logs Not Being Created

**Error**: `logs folder not found or logs not generated`

**Solution**:
```csharp
// Ensure logs directory exists
// Serilog will create it automatically, but verify permissions
// Check appsettings.json Serilog configuration

// Create manually if needed:
// Create folder: bin/Debug/net8.0/logs/
```

### Issue 8: Null Reference Exception

**Error**: `Object reference not set to an instance`

**Solution**:
```csharp
// Check null before using
if (entity != null)
{
    // Process entity
}

// Or use null-coalescing operator
var result = entity ?? new Entity();

// Use null-forgiving operator if certain
var property = entity!.PropertyName;
```
