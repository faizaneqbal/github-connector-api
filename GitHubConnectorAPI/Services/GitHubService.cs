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

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch repositories: {response.StatusCode}");
            }

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

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch User data: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();

            // Convert JSON → DTO
            var user = JsonSerializer.Deserialize<GitHubUserDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return user ?? new GitHubUserDto();
        }

        public async Task<CreateIssueResponse?> CreateIssue(CreateIssueRequest request)
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

            // Ensure the response is successful
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"GitHub API failed: {response.StatusCode}");
            }

            // Read response
            var responseContent = await response.Content.ReadAsStringAsync();

            // Parse the JSON response content into a JsonDocument for easy access to properties
            using var doc = JsonDocument.Parse(responseContent);

            // Get the root element of the JSON document
            var root = doc.RootElement;

            // Create a new CreateIssueResponse object and populate its properties from the JSON response
            var issue = new CreateIssueResponse
            {
                Title = root.GetProperty("title").GetString(), // Extract the title of the issue
                Url = root.GetProperty("html_url").GetString(), // Extract the URL of the created issue
                Number = root.GetProperty("number").GetInt32() // Extract the issue number
            };

            // Return the populated CreateIssueResponse object
            return issue;

        }
    }
}