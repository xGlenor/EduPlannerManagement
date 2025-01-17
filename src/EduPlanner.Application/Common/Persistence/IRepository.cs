using System.Linq.Expressions;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Application.Common.Persistence;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();
    TEntity FindOne(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    void Add(TEntity entity);
    void AddMany(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteMany(Expression<Func<TEntity, bool>> predicate);
    bool Any(Expression<Func<TEntity, bool>> predicate);
    int Count(Expression<Func<TEntity, bool>> predicate);
}