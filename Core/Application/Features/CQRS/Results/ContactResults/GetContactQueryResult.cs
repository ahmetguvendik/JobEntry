namespace JobEntry.Application.Features.CQRS.Results.ContactResults;

public class GetContactQueryResult
{
    public string Id { get; set; }
    public string Adress { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}