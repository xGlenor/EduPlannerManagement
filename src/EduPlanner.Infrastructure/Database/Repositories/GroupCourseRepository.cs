using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class GroupCourseRepository : ReadOnlyRepository<GroupCourse>, IGroupCourseRepository
{
    public GroupCourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}