using System.Linq.Expressions;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> 
    where TEntity : class
{    
    private readonly DbContext _dbContext;
    protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

    protected ReadOnlyRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<TEntity>> GetAll()
        => DbSet.ToListAsync();
    
    public Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        => DbSet.FirstOrDefaultAsync(predicate);

    public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        => DbSet.Where(predicate).ToListAsync();

    public Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        => DbSet.AnyAsync(predicate);

    public Task<int> Count(Expression<Func<TEntity, bool>> predicate)
        => DbSet.CountAsync(predicate);
}