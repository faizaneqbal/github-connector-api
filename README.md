\# GitHub Connector API



A simple ASP.NET Core Web API that connects to the GitHub API and exposes custom REST endpoints.



\## 📌 Overview



This project demonstrates how to:



\- Authenticate with GitHub using a Personal Access Token (PAT)

\- Fetch user repositories

\- Fetch user profile information

\- Create GitHub issues via API

\- Apply clean architecture using Controller → Service → DTO pattern



\## 🚀 Features



\- Get authenticated user's GitHub repositories

\- Get authenticated user's profile details

\- Create GitHub issues via API

\- Clean API responses using DTOs

\- Error handling at controller level



\---



\## ⚙️ Tech Stack



\- ASP.NET Core Web API

\- C#

\- GitHub REST API

\- Swagger / OpenAPI

\- Dependency Injection (DI)

\- System.Text.Json



\## 📂 Project Structure



```text

github-connector-api

│

├── GitHubConnectorAPI.sln

├── README.md

│

└── GitHubConnectorAPI/

&#x20;   ├── Controllers

&#x20;   │   └── GitHubController.cs

&#x20;   │

&#x20;   ├── Services

&#x20;   │   ├── IGitHubService.cs

&#x20;   │   └── GitHubService.cs

&#x20;   │

&#x20;   ├── Models

&#x20;   │   ├── RepoDto.cs

&#x20;   │   ├── GitHubUserDto.cs

&#x20;   │   ├── CreateIssueRequest.cs

&#x20;   │   └── CreateIssueResponse.cs

&#x20;   │

&#x20;   └── Program.cs



\## 🏗️ Architecture



The project follows a clean and simple architecture:



`Client → Controller → Service → GitHub API`



\### Responsibilities



\*\*Controller\*\*

\- Handles HTTP requests and responses

\- Manages error handling

\- Does not contain business logic



\*\*Service\*\*

\- Contains business logic

\- Communicates with GitHub API

\- Handles data transformation



\*\*DTOs (Models)\*\*

\- Define request and response structure

\- Ensure clean and controlled API output

