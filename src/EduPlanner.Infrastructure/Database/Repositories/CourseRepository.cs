using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}