namespace GitHubConnectorAPI.Services
{

    // This class implements IGitHubService
    // It will contain actual logic to call GitHub API
    public class GitHubService : IGitHubService
    {
        // This method will later call GitHub API
        public Task<string> GetUserRepositories()
        {
            // Temporary response (we will replace this soon)
            return Task.FromResult("Not implemented yet");
        }
    }
}