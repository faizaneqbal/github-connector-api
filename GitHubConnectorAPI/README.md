# GitHub Connector API

## 📌 Overview
This project is an ASP.NET Core Web API that connects with GitHub API and exposes custom endpoints.

---

## 🏗️ Architecture

Controller → Service → GitHub API

- Controller: Handles HTTP requests
- Service: Contains business logic
- GitHub API: External system

---

## ⚙️ Tech Stack
- .NET 8/9 Web API
- Dependency Injection (DI)
- GitHub REST API

---

## 🚀 How to Run

1. Open solution in Visual Studio
2. Run project (F5)
3. Open Swagger:
   https://localhost:{port}/swagger

---

## 📡 API Endpoints

### GET /api/github/repos
Returns list of repositories (currently placeholder)

---

## 🔐 Notes
- GitHub Personal Access Token (PAT) will be used for authentication
- Token should NOT be hardcoded (will be improved later)

---

## 📌 Future Improvements
- Real GitHub API integration
- Secure token handling
- Response models instead of raw string