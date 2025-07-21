using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal abstract class Repository<TEntity> : ReadOnlyRepository<TEntity>, Domain.Repositories.Repository<TEntity> 
    where TEntity : class
{
    protected Repository(DbContext dbContext) : base(dbContext)
    {
    }

    public void Add(TEntity entity)
        => DbSet.Add(entity);

    public void AddMany(IEnumerable<TEntity> entities)
        => DbSet.AddRange(entities);

    public void Delete(TEntity entity)
        => DbSet.Remove(entity);
    
    public void DeleteMany(IEnumerable<TEntity> entities)
        => DbSet.RemoveRange(entities);
    
    public void Update(TEntity entity)
        => DbSet.Update(entity);
}