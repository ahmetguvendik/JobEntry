using JobEntry.Application.Repositories;
using JobEntry.Domain.Entities;
using JobEntry.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobEntry.Persistance.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly JobEntryDbContext  _context;

    public CompanyRepository(JobEntryDbContext context)
    {
         _context = context;
    }
    public async Task<List<Company>> GetCompanyByUserid(string userid)
    {
        var value =  _context.Companies.Include(x=>x.AppUser).Where(y=>y.AppUserId == userid).ToList();
        return value;
    }
}