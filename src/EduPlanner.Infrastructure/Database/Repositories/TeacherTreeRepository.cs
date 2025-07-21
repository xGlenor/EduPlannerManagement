using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class TeacherTreeRepository : ReadOnlyRepository<TeacherTree>, ITeacherTreeRepository
{
    public TeacherTreeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}