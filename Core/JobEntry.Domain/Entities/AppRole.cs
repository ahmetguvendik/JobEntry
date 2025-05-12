using Microsoft.AspNetCore.Identity;

namespace JobEntry.Domain.Entities;

public class AppRole : IdentityRole<string>
{
    public AppRole()
    {
        Id = Guid.NewGuid().ToString(); // string beklediği için ToString() ekledik
    }
}