using System.Linq.Expressions;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    protected BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
        => DbSet.Add(entity);

    public void AddMany(IEnumerable<TEntity> entities)
        => DbSet.AddRange(entities);

    public void Delete(TEntity entity)
        => DbSet.Remove(entity);
    
    public void DeleteMany(IEnumerable<TEntity> entities)
        => DbSet.RemoveRange(entities);

    public Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        => DbSet.FirstOrDefaultAsync(predicate)!;

    public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        => DbSet.Where(predicate).ToListAsync();

    public Task<List<TEntity>> GetAll()
        => DbSet.ToListAsync();

    public void Update(TEntity entity)
        => DbSet.Update(entity);

    public Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => DbSet.AnyAsync(predicate);

    public Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        => DbSet.CountAsync(predicate);
}