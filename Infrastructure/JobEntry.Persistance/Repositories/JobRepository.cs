using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using JobEntry.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobEntry.Persistance.Repositories;

public class JobRepository : IJobRepository
{
    private readonly JobEntryDbContext _context;

    public JobRepository( JobEntryDbContext context)
    {
         _context = context;
    }
    public async Task<List<Job>> Get5JobWithPropertyAsync()
    {
        var value = _context.Jobs
            .Include(x => x.Company)         // Navigation Property
            .Include(y => y.Location)        // Navigation Property (LocationId DEĞİL!)
            .Include(z => z.JobType)         // Navigation Property
            .Take(5)
            .ToList();        
        return value;
    }
}