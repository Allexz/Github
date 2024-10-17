namespace RefitExample.Model;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value 
public class GitHubUser
{
    public string Name { get; set; }
    public string Company { get; set; }
    public int Followers { get; set; }
    public int Following { get; set; }
    public string AvatarUrl { get; set; }
}
