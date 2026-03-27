using System.Text.Json.Serialization;

namespace GitHubConnectorAPI.Models
{
    //It is a simple Data Transfer Object (DTO) to represent a GitHub repository. (Only send required data to client)
    public class RepoDto
    {
        // Repository name
        // Maps "name" from JSON
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        // Full repository name (owner/repo)
        // Maps "full_name" from JSON
        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }
    }
}