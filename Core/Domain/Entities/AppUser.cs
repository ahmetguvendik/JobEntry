using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JobEntry.Domain.Entities;

public class AppUser: IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString(); // string beklediği için ToString() ekledik
        ApplyJobs = new List<ApplyJob>(); // Listeyi başlatıyoruz
    }

    public List<ApplyJob> ApplyJobs { get; set; }
}