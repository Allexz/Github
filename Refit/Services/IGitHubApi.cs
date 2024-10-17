using Refit;
using RefitExample.Model;

namespace RefitExample.Services;

public interface IGitHubApi
{
    [Get("/users/{username}")]
    Task<GitHubUser> GetUserAsync(string username);
}
