# ERP System - Clean Architecture Implementation

Enterprise Resource Planning (ERP) System is a modular, scalable, and maintainable ERP system built with **ASP.NET Core**, following **Clean Architecture**, **CQRS**, and **Repository Pattern** principles.

---

## 🛠️ Features

### Core Modules:
- **Product Management**
  - Add, update, delete, and view products.
- **Order Management**
  - Create, update, and track orders.
- **Inventory Management**
  - Manage stock levels and receive low-stock alerts.

### Upcoming Features:
- **Reporting**
  - Sales and inventory reports.
- **User Authentication**
  - Role-based access control (RBAC).
- **Employee Management**
  - Manage employees and track performance.

---

## 🎯 Architecture

This project adheres to **Clean Architecture** principles, ensuring:
1. **Separation of Concerns:** Layers are independent and communicate via interfaces.
2. **Testability:** The domain and application logic can be tested independently.
3. **Scalability:** The application can evolve with new modules and technologies.

### Layered Structure:
- **Domain Layer:** Contains core business logic and entities.
- **Application Layer:** Implements use cases and business workflows.
- **Infrastructure Layer:** Handles data access, repository implementations, and external APIs.
- **Presentation Layer (API):** Exposes REST endpoints to clients.

---

## ⚙️ Technology Stack

- **Backend:** ASP.NET Core
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Pattern:** Clean Architecture with CQRS
- **Tools:** MediatR, FluentValidation, AutoMapper

---

## 📂 Folder Structure

