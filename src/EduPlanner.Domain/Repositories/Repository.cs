using System.Linq.Expressions;

namespace EduPlanner.Domain.Repositories;

public interface Repository<TEntity> : IReadOnlyRepository<TEntity> 
    where TEntity : class
{
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteMany(IEnumerable<TEntity> entities);
}