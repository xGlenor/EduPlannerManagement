using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class WeekWeekTypeRepository : ReadOnlyRepository<WeekWeekType>, IWeekWeekTypeRepository
{
    public WeekWeekTypeRepository(DbContext dbContext) : base(dbContext)
    {
    }
}