using System.Linq.Expressions;

namespace src.Features;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T model);
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T> UpdateAsync(T model);
    Task DeleteAsync(T model);
}