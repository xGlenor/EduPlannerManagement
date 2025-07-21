using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class RoomCourseRepository : ReadOnlyRepository<RoomCourse>, IRoomCourseRepository
{
    public RoomCourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}