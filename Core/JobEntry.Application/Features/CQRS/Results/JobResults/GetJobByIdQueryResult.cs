namespace JobEntry.Application.Features.CQRS.Results.JobResults;

public class GetJobByIdQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishedTime { get; set; }
    public string CompanyId { get; set; }   
    public DateTime EndTime { get; set; }
    public string LocationId { get; set; }
    public string JobTypeId { get; set; }
    public string JobStyleId { get; set; }
    public string Salary { get; set; }
}