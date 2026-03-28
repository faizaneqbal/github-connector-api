namespace GitHubConnectorAPI.Models
{
    public class CreateIssueRequest
    {
        public string RepoName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string? Body { get; set; }
    }
}