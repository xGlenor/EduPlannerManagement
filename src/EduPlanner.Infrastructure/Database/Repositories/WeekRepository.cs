using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Repositories;

internal sealed class WeekRepository : BaseRepository<Week>, IWeekRepository
{
    public WeekRepository(DbContext dbContext) : base(dbContext)
    {
    }
}