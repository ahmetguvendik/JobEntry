namespace JobEntry.Application.Features.CQRS.Results.AboutResults;

public class GetAboutQueryResult
{
    public string Id { get; set; }  
    public string Title { get; set; }
    public string Description { get; set; }
}