using System.Collections.Generic;

namespace JobEntry.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string IconURL { get; set; }
    public List<Job> Jobs { get; set; }
}