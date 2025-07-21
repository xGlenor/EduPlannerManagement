using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class RoomRepository : ReadOnlyRepository<Room>, IRoomRepository
{
    public RoomRepository(DbContext dbContext) : base(dbContext)
    {
    }
}