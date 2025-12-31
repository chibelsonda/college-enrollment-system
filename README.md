# 🎓 College Enrollment System

🚧 **PROJECT STATUS: UNDER CONSTRUCTION** 🚧  

This project is actively being developed.  
Features, structure, and implementation may change as the system evolves.

---

A web-based **College Enrollment System** built using **ASP.NET Core MVC and Web API**.  
The system manages students, authentication, roles, and enrollment-related data with a clean MVC structure and RESTful APIs.

This project is designed for learning, demonstration, and real-world application use.

---

## 🚀 Features (Current & In Progress)

- ✅ User authentication (Register / Login / Logout)
- ✅ Role-based access (Admin, Student)
- ✅ Student CRUD (Create, Read, Update, Delete)
- ✅ MVC pages + REST API endpoints
- ✅ API versioning
- ✅ Swagger API documentation
- ✅ Secure password hashing
- 🔄 Enrollment module (in progress)
- 🔄 Course management (planned)

---

## 🛠️ Tech Stack

- **Backend Framework:** ASP.NET Core (MVC + Web API)
- **Language:** C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Core Identity + JWT
- **Frontend:** Razor Views + Bootstrap 5
- **API Documentation:** Swagger (OpenAPI)

---

## 🔐 Authentication & Authorization

- ASP.NET Core Identity for user management
- JWT authentication for API endpoints
- Role-based authorization (Admin / Student)
- Secure password hashing

---

## 📄 API Versioning

- Default version: **v1**
- URL-based versioning
- Swagger grouped by version

Example:
/api/v1/students

---

## 📊 Swagger API Documentation

Swagger UI is enabled for API testing:

https://localhost
:<port>/swagger

---

## 🗄️ Database Setup

1. Update the connection string in `appsettings.json`
2. Run migrations:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update

```

## ▶️ Running the Project
dotnet restore
dotnet build
dotnet run

Then open:

https://localhost:<port>

---

## 📌 Planned Improvements

Enrollment workflow

Course and subject management

Student dashboard

Pagination & filtering

Improved UI/UX

Unit & integration testing

## 👨‍💻 Author

Chicote
Web Developer / Full-Stack Developer
ASP.NET Core • C# • SQL Server • React

## 📜 License

This project is under active development and intended for educational and demonstration purposes.