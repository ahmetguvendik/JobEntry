using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobEntry.Application.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task RemoveAsync(T entity);
    Task SaveChangesAsync();
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);

}