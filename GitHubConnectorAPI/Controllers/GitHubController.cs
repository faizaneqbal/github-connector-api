using Microsoft.AspNetCore.Mvc;
using GitHubConnectorAPI.Services;

namespace GitHubConnectorAPI.Controllers
{
    // This tells ASP.NET that this is an API controller
    [ApiController]

    // Base route: api/github
    [Route("api/github")]
    public class GitHubController : ControllerBase
    {
        // This is our service (business logic layer)
        private readonly IGitHubService _gitHubService;

        // Constructor Injection (Dependency Injection)
        public GitHubController(IGitHubService gitHubService)
        {
            // .NET automatically gives us the object because of AddScoped
            _gitHubService = gitHubService;
        }

        // Endpoint: GET api/github/repos
        [HttpGet("repos")]
        public async Task<IActionResult> GetRepositories()
        {
            // Calling service (NOT writing logic here)
            var result = await _gitHubService.GetUserRepositories();

            // Returning response
            return Ok(result);
        }

        // GET api/github/user
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _gitHubService.GetUserProfile();

            return Ok(result);
        }
    }
}