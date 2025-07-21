using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class WeekTypeRepository : ReadOnlyRepository<WeekType>, IWeekTypeRepository
{
    public WeekTypeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}