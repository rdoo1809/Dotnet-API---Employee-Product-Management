# Employee & Product Management API

This project is an academic assignment built with **.NET 8 Web API**.  
It demonstrates clean architecture practices using the **Repository Pattern**, **Unit of Work Pattern**, and **Dependency Injection** to manage Employees and Products.

---

## 🚀 Tech Stack
- **.NET 8 Web API**
- **Entity Framework Core**
- **SQL Server (localdb)** for persistence
- **Dependency Injection**
- Tested with **Postman**

---

## 📦 Project Setup

1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd <your-project-folder>

2. Restore dependencies:
   ```bash
   dotnet restore

3. Apply migrations & seed the database:
   ```bash
   dotnet ef database update

4. Run the project:
   ```bash
   dotnet run



### API Endpoints

Employees
•	GET /api/employees → Get all employees
•	GET /api/employees/{id} → Get employee by ID
•	POST /api/employees → Create new employee
•	PUT /api/employees/{id} → Update existing employee
•	DELETE /api/employees/{id} → Delete employee

Products
•	GET /api/products → Get all products
•	GET /api/products/{id} → Get product by ID
•	POST /api/products → Create new product
•	PUT /api/products/{id} → Update existing product
•	DELETE /api/products/{id} → Delete product


### Testing

You can test the API endpoints using Postman or any other REST client.
All endpoints return proper JSON responses and HTTP status codes.

⸻

### Notes
•	This project is strictly for academic purposes.
•	Database seeding creates 2 Employees and 2 Products by default.
•	All data access is handled via repositories and coordinated with Unit of Work.