using System;
using Microsoft.AspNetCore.Identity;

namespace JobEntry.Domain.Entities;

public class AppUser: IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString(); // string beklediği için ToString() ekledik
    }
}