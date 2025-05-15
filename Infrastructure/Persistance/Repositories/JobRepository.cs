using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            .Include(x => x.Company)        
            .Include(y => y.Location)        
            .Include(z => z.JobType)        
            .Take(5)
            .ToList();        
        return value;
    }

    public async Task<List<Job>> GetAllJobWithPropertyAsync()
    {
        var value = _context.Jobs
            .Include(x => x.Company)
            .Include(y => y.Location)       
            .Include(z => z.JobType)         
            .ToList();        
        return value;
    }

    public async Task<Job> GetJobByIdWithPropertyAsync(string id)
    {
        var job = await _context.Jobs
            .Include(x => x.Company)
            .Include(x => x.Location)
            .Include(x => x.JobType)
            .FirstOrDefaultAsync(j => j.Id == id);
        return job;
    }

    public async Task<List<Job>> GetJobByIdCompanyIdAsync(string id)
    {
        var jobs = await _context.Jobs
            .Include(x => x.Company)
            .Include(x => x.Location)
            .Include(x => x.JobType)
            .Include(x => x.JobStyle)
            .Where(x=>x.CompanyId==id).ToListAsync();
        return jobs;
    }
}