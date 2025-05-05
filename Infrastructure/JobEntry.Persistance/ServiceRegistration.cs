using JobEntry.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobEntry.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection collection)
    {
        collection.AddDbContext<JobEntryDbContext>(opt =>
            opt.UseNpgsql("User ID=postgres;Password=testtest;Host=localhost;Port=5432;Database=JobEntryDb;"));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
    }
}