namespace JobEntry.DTO.JobDTOs;

public class GetJobByCategoryAndLocationIdDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime PublishedTime { get; set; }
    public string CompanyName { get; set; }   
    public DateTime EndTime { get; set; }
    public string LocationName { get; set; }
    public string JobTypeName { get; set; }
    public string JobStyleName { get; set; }
    public string Salary { get; set; }
    public string CategoryId { get; set; }
    public string LocationId { get; set; }
}