using System;

namespace JobEntry.Application.Features.CQRS.Results.JobResults;

public class Get5JobWithPropertyQueryResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishedTime { get; set; }
    public string CompanyImageURL { get; set; }   
    public DateTime EndTime { get; set; }
    public string LocationName { get; set; }
    public string JobTypeName { get; set; }
    public string Salary { get; set; }
}