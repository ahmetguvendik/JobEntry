namespace JobEntry.Application.Features.CQRS.Results.AppUserResults;

public class GetAppUserQueryResult
{
    public string Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
}