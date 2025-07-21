using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class GroupTreeRepository : ReadOnlyRepository<GroupTree>, IGroupTreeRepository
{
    public GroupTreeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}