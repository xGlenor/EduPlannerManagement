using System.Linq.Expressions;
using EduPlanner.Application.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;
    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }


   public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
        _dbContext.SaveChanges();
    }
    public void AddMany(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
        _dbContext.SaveChanges();
    }
    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        _dbContext.SaveChanges();
    }
    public void DeleteMany(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = Find(predicate);
        _dbContext.Set<TEntity>().RemoveRange(entities);
        _dbContext.SaveChanges();
    }
    public TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
    {
        return Get().FirstOrDefault(predicate)!;
    }
    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Get().Where(predicate);
    }
    public IQueryable<TEntity> GetAll()
    {
        return Get();
    }
    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
        _dbContext.SaveChanges();
    }
    public bool Any(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbContext.Set<TEntity>().Any(predicate);
    }
    public int Count(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbContext.Set<TEntity>().Count(predicate);
    }
    private DbSet<TEntity> Get()
    {
        var entity = _dbContext.Set<TEntity>();
        return entity;
    }
}