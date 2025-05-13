namespace JobEntry.Application.Features.CQRS.Results.CompanyResults;

public class GetCompanyByIdQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
}