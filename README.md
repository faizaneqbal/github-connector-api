# GitHub Connector API

A simple ASP.NET Core Web API that connects to the GitHub API and exposes custom REST endpoints.

## 📌 Overview

This project demonstrates how to:

- Authenticate with GitHub using a Personal Access Token (PAT)
- Fetch user repositories
- Fetch user profile information
- Create GitHub issues via API
- Apply clean architecture using Controller → Service → DTO pattern

## 🚀 Features

- Get authenticated user's GitHub repositories
- Get authenticated user's profile details
- Create GitHub issues via API
- Clean API responses using DTOs
- Error handling at controller level

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