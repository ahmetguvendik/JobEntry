using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using JobEntry.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobEntry.Persistance.Repositories;

public class ApplyJobRepository : IApplyJobRepository
{
    private readonly JobEntryDbContext _context;

    public ApplyJobRepository( JobEntryDbContext context)
    {
         _context = context;
    }
    
    public async Task<List<ApplyJob>> GetApplyJobByUserid(string id)
    {
        var values = await _context.ApplyJobs.
            Include(j => j.Job).
            Include(x=>x.AppUser).Where(y=>y.AppUserId == id).ToListAsync();
        return values;
    }
}