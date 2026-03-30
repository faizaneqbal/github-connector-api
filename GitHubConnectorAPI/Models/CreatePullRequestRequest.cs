namespace GitHubConnectorAPI.Models
{
    public class CreatePullRequestRequest
    {
        public string RepoName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string Head { get; set; } = string.Empty; // source branch

        public string Base { get; set; } = string.Empty; // target branch
    }
}