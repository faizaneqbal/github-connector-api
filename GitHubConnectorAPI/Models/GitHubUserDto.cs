using System.Text.Json.Serialization;

namespace GitHubConnectorAPI.Models
{
    public class GitHubUserDto
    {
        // Maps "login"
        [JsonPropertyName("login")]
        public string? Login { get; set; }

        // Maps "name"
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        // Maps "public_repos"
        [JsonPropertyName("public_repos")]
        public int PublicRepos { get; set; }
    }
}