namespace GitHubConnectorAPI.Models
{
    public class CreatePullRequestResponse
    {
        public string? Title { get; set; }

        public string? Url { get; set; }

        public int Number { get; set; }
    }
}