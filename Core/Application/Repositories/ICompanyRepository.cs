using JobEntry.Domain.Entities;

namespace JobEntry.Application.Repositories;

public interface ICompanyRepository
{
    Task<List<Company>> GetCompanyByUserid(string userid);  
}