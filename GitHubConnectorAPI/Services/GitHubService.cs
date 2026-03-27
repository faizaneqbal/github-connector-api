using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

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
        public async Task<string> GetUserRepositories()
        {
            // Calling GitHub API endpoint to fetch user repositories
            var response = await _httpClient.GetAsync("https://api.github.com/user/repos");

            // Read response content as string (JSON format)
            var content = await response.Content.ReadAsStringAsync();

            return content; // Return the JSON content
        }
    }
}