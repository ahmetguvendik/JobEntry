using JobEntry.Domain.Entities;

namespace JobEntry.Application.Repositories;

public interface IApplyJobRepository
{
    Task<List<ApplyJob>> GetApplyJobByUserid(string id);        
}