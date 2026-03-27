namespace GitHubConnectorAPI.Services
{
    public interface IGitHubService
    {
        Task<string> GetUserRepositories();
    }
}
