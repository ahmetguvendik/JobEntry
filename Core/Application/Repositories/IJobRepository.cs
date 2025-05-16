using System.Collections.Generic;
using System.Threading.Tasks;
using JobEntry.Domain.Entities;

namespace JobEntry.Application.Repositories;

public interface IJobRepository
{
    Task<List<Job>> Get5JobWithPropertyAsync(); 
    Task<List<Job>> GetAllJobWithPropertyAsync(); 
    Task<Job> GetJobByIdWithPropertyAsync(string id);       
    Task<List<Job>> GetJobByIdCompanyIdAsync(string id);      
    Task<List<Job>> GetJobByIdCategoryIdAsync(string id);       
}