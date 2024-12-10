using System.Linq.Expressions;

namespace lms.Data;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
}
