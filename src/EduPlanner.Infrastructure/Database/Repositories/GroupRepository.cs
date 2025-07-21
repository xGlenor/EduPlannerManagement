using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class GroupRepository : ReadOnlyRepository<Group>, IGroupRepository
{
    public GroupRepository(DbContext dbContext) : base(dbContext)
    {
    }
}