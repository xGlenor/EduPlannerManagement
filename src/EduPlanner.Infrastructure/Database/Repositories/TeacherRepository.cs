using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(DbContext dbContext) : base(dbContext)
    {
    }
}