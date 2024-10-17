using Microsoft.AspNetCore.Mvc;
using RefitExample.Services;

namespace RefitExample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
    private readonly IGitHubApi gitHubApi;
    public GitHubController(IGitHubApi gitHubApi)
    {
        this.gitHubApi = gitHubApi;
    }

    [HttpGet, Route("user/{username}")]
    public async Task<IActionResult> GetUser([FromRoute] string username)
    {
        var user = await gitHubApi.GetUserAsync(username);
        return Ok(user);
    }

}
