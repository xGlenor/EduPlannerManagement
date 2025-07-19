using System.Linq.Expressions;

namespace EduPlanner.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteMany(IEnumerable<TEntity> entities);
    Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
    Task<int> Count(Expression<Func<TEntity, bool>> predicate);
}