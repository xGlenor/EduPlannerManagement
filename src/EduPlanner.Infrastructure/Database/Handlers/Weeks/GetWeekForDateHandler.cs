using MediatR;
using EduPlanner.Application.Weeks;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Weeks;

internal class GetWeekForDateHandler(NewDbContext dbContext)  : IRequestHandler<GetWeekForDate, WeekDTO?>
{
    public async Task<WeekDTO?> Handle(GetWeekForDate request, CancellationToken cancellationToken)
    {
        var week = await dbContext
            .Weeks
            .OrderBy(x=>x.StartWeek)
            .LastOrDefaultAsync(x=>x.StartWeek <= request.Date, cancellationToken);

        return week is null 
            ? null 
            : new WeekDTO(week.Id, week.StartWeek, week.Description);
    }
}