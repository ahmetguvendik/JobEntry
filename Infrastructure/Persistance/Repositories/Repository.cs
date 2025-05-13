using System.Collections.Generic;
using System.Threading.Tasks;
using JobEntry.Application.Repositories;
using JobEntry.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JobEntry.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly JobEntryDbContext  _context;

    public Repository( JobEntryDbContext context)
    {
             _context = context;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync(); 
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}