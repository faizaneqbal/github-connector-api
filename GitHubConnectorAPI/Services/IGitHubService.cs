using GitHubConnectorAPI.Models;

namespace GitHubConnectorAPI.Services
{
    public interface IGitHubService
    {
        Task<List<RepoDto>> GetUserRepositories();

        Task<GitHubUserDto?> GetUserProfile();
    }
}
