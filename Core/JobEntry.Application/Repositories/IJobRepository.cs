using JobEntry.Domain.Entities;

namespace JobEntry.Application.Repositories;

public interface IJobRepository
{
    Task<List<Job>> Get5JobWithPropertyAsync(); 
    Task<List<Job>> GetAllJobWithPropertyAsync(); 
    Task<Job> GetJobByIdWithPropertyAsync(string id);       
}