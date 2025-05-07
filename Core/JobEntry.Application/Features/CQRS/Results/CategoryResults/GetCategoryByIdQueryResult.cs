namespace JobEntry.Application.Features.CQRS.Results.CategoryResults;

public class GetCategoryByIdQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string IconURL { get; set; }
}