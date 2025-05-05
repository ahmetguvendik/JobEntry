namespace JobEntry.Domain.Entities;

public class JobStyle : BaseEntity  
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }
}