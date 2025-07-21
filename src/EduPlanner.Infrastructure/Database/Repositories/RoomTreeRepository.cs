using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class RoomTreeRepository : ReadOnlyRepository<RoomTree>, IRoomTreeRepository
{
    public RoomTreeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}