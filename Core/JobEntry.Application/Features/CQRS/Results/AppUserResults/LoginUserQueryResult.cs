namespace JobEntry.Application.Features.CQRS.Results.AppUserResults;

public class LoginUserQueryResult
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}