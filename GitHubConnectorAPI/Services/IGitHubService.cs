using GitHubConnectorAPI.Models;

namespace GitHubConnectorAPI.Services
{
    public interface IGitHubService
    {
        // Method to retrieve a list of repositories for the authenticated user
        Task<List<RepoDto>> GetUserRepositories();

        // Method to get the profile information of the authenticated user
        Task<GitHubUserDto?> GetUserProfile();

        // Method to create a new issue in a repository
        Task<CreateIssueResponse?> CreateIssue(CreateIssueRequest request);
    }
}
