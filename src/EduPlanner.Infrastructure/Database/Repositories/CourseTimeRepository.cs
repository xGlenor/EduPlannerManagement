using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class CourseTimeRepository : ReadOnlyRepository<CourseTime>, ICourseTimeRepository
{
    public CourseTimeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}