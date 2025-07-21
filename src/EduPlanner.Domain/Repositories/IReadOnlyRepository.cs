using System.Linq.Expressions;

namespace EduPlanner.Domain.Repositories;

public interface IReadOnlyRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
    Task<int> Count(Expression<Func<TEntity, bool>> predicate);
}