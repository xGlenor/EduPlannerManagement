using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class TeacherCourseRepository : ReadOnlyRepository<TeacherCourse>, ITeacherCourseRepository
{
    public TeacherCourseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}