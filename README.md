# GitHub Connector API

A simple ASP.NET Core Web API that connects to the GitHub API and exposes custom REST endpoints.

## 📌 Overview

This project demonstrates how to:

- Authenticate with GitHub using a Personal Access Token (PAT)
- Fetch user repositories
- Fetch user profile information
- Create GitHub issues via API
- Create GitHub Pull Request via API
- Apply clean architecture using Controller → Service → DTO pattern

## 🚀 Features

- Get authenticated user's GitHub repositories
- Get authenticated user's profile details
- Create GitHub issues via API
- Create GitHub pull requests via API (bonus feature)
- Clean API responses using DTOs

## ⚠️ Error Handling
- API returns meaningful error messages
- Controller-level exception handling is implemented

---

## ⚙️ Tech Stack

- ASP.NET Core Web API
- C#
- GitHub REST API
- Swagger / OpenAPI
- Dependency Injection (DI)
- System.Text.Json

## 📂 Project Structure

```text
github-connector-api
│
├── GitHubConnectorAPI.sln
├── README.md
│
└── GitHubConnectorAPI/
    ├── Controllers/
    │   └── GitHubController.cs
    │
    ├── Services/
    │   ├── IGitHubService.cs
    │   └── GitHubService.cs
    │
    ├── Models/
    │   ├── RepoDto.cs
    │   ├── GitHubUserDto.cs
    │   ├── CreateIssueRequest.cs
    │   └── CreateIssueResponse.cs
    │
    └── Program.cs
```
## 🏗️ Architecture

The project follows a clean and simple architecture:

`Client → Controller → Service → GitHub API`

### Responsibilities

**Controller**
- Handles HTTP requests and responses
- Manages error handling
- Does not contain business logic

**Service**
- Contains business logic
- Communicates with GitHub API
- Handles data transformation

**DTOs (Models)**
- Define request and response structure
- Ensure clean and controlled API output

## ⚙️ Setup Instructions

### Prerequisites

Make sure you have the following installed:

- .NET SDK
- Visual Studio 2022
- Git
- GitHub account
- GitHub Personal Access Token (PAT)

---

### Steps to Run

1. Clone the repository

```bash
git clone <your-repo-url>
```
2. Open the solution in Visual Studio

3. Configure GitHub Token using User Secrets

```json
{
  "GitHub:Token": "your_token_here"
}
```
4. Run the project (F5)

5. Open Swagger in browser and test APIs


## 📡 API Endpoints

### 1. Get Repositories

**GET** `/api/github/repos`

Returns the authenticated user's repositories.

### 2. Get User Profile

**GET** `/api/github/user`

Returns GitHub user details.

### 3. Create Issue

**POST** `/api/github/issues`

Creates an issue in a GitHub repository.


#### Request Body

```json
{
  "repoName": "github-connector-api",
  "title": "Test Issue from API",
  "body": "This issue was created via API"
}
```
#### Sample Response

```json
{
  "title": "Test Issue from API",
  "url": "https://github.com/username/repository/issues/1",
  "number": 1
}
```

### 4. Create Pull Request (Bonus)

**POST** `/api/github/pull-request`

Creates a pull request between two branches in a repository.

#### Request Body

```json
{
  "repoName": "github-connector-api",
  "title": "Test PR from API",
  "head": "feature-branch",
  "base": "master"
}
```

#### Sample Response

```json
{
  "title": "Test PR from API",
  "url": "https://github.com/username/repository/pull/1",
  "number": 1
}
```

## 🧠 What I Learned

This project helped me understand:

- Dependency Injection (DI)
- Service layer architecture
- REST API design
- DTO (Data Transfer Objects)
- JSON serialization and deserialization
- External API integration (GitHub API)
- Error handling in ASP.NET Core

## 📌 Future Improvements

- Add global exception handling middleware
- Add logging
- Add validation for request models
- Support more GitHub actions (e.g., create repository, update issues)
- Move configuration fully to secure environment variables

---

## 👨‍💻 Author
**Md Faizan Eqbal**

