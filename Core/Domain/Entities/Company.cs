using System.Collections.Generic;

namespace JobEntry.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LogoUrl { get; set; }
    public List<Job> Jobs { get; set; }
    public AppUser? AppUser { get; set; }
    public string? AppUserId { get; set; }
}