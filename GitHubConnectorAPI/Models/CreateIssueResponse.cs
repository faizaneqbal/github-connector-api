using System.Text.Json.Serialization;

namespace GitHubConnectorAPI.Models
{
    public class CreateIssueResponse
    {
        // Issue title
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        // Issue URL (important for user)
       // [JsonPropertyName("html_url")]
        public string? Url { get; set; }

        // Issue number
        [JsonPropertyName("number")]
        public int Number { get; set; }
    }
}