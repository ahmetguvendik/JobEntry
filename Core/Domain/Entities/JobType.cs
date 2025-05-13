using System.Collections.Generic;

namespace JobEntry.Domain.Entities;

public class JobType : BaseEntity
{
    public string Name { get; set; }
    public List<Job> Jobs { get; set; }

}