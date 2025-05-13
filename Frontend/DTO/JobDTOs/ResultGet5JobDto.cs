namespace JobEntry.DTO.JobDTOs;

public class ResultGet5JobDto
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