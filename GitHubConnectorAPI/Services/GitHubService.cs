using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using GitHubConnectorAPI.Models;
using System.Text;

namespace GitHubConnectorAPI.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient; // HttpClient instance for making API calls

        // Constructor
        public GitHubService(IConfiguration configuration)
        {
            // Retrieve the GitHub Personal Access Token from configuration
            var token = configuration["GitHub:Token"];

            _httpClient = new HttpClient(); // Initialize HttpClient

            // GitHub requires a User-Agent header for API requests
            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue("DotNetApp", "1.0"));

            // Set Authorization header using the Personal Access Token
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        // Method to get user repositories from GitHub
        public async Task<List<RepoDto>> GetUserRepositories()
        {
            // Send a GET request to the GitHub API to retrieve user repositories
            var response = await _httpClient.GetAsync("https://api.github.com/user/repos");

            // Read the response content as a string
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize JSON into a list of RepoDto objects
            var repos = JsonSerializer.Deserialize<List<RepoDto>>(content, new JsonSerializerOptions
            {
                // Ensure property names are case insensitive during deserialization
                PropertyNameCaseInsensitive = true
            });

            // Return the list of repositories or an empty list if deserialization fails
            return repos ?? new List<RepoDto>();
        }

        // Method to get user profile information from GitHub
        public async Task<GitHubUserDto?> GetUserProfile()
        {
            // Call GitHub API
            var response = await _httpClient.GetAsync("https://api.github.com/user");

            var content = await response.Content.ReadAsStringAsync();

            // Convert JSON → DTO
            var user = JsonSerializer.Deserialize<GitHubUserDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return user;
        }

        public async Task<string> CreateIssue(CreateIssueRequest request)
        {
            // Prepare API URL (replace with your username)
            var url = $"https://api.github.com/repos/faizaneqbal/{request.RepoName}/issues";

            // Create request body (what GitHub expects)
            var issueData = new
            {
                title = request.Title,
                body = request.Body
            };

            // Convert C# object → JSON string
            var json = JsonSerializer.Serialize(issueData);

            // Convert to HTTP content
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send POST request
            var response = await _httpClient.PostAsync(url, content);

            // Read response
            return await response.Content.ReadAsStringAsync();
        }
    }
}