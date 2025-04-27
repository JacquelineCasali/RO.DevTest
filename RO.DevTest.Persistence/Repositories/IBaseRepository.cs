using System.Linq.Expressions;

public interface IBaseRepository<T> where T : class
{
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
}