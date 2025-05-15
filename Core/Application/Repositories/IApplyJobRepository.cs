using System.Linq.Expressions;
using JobEntry.Domain.Entities;

namespace JobEntry.Application.Repositories;

public interface IApplyJobRepository
{
    Task<List<ApplyJob>> GetApplyJobByUserid(string id);        
    Task<List<ApplyJob>> GetApplyJobWithJobByCompanyIdAsync(string id);  
    Task<ApplyJob> GetByFilterAsync(Expression<Func<ApplyJob, bool>> filter);
}