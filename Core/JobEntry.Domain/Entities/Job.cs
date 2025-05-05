namespace JobEntry.Domain.Entities;

public class Job : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishedTime { get; set; }
    public Company Company { get; set; }
    public string CompanyId { get; set; }   
    public DateTime EndTime { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; }
    public string JobTypeId { get; set; }
    public JobType JobType { get; set; }
    public string JobStyleId { get; set; }
    public JobStyle JobStyle { get; set; }
    public string Salary { get; set; }
    
    
}