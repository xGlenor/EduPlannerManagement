using EduPlanner.Application.Weeks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Weeks;

internal class GetWeekForIdHandler(NewDbContext dbContext) : IRequestHandler<GetWeekForId, WeekDTO?>
{
    public async Task<WeekDTO?> Handle(GetWeekForId request, CancellationToken cancellationToken)
    {
        var week = await dbContext
            .Weeks
            .FirstOrDefaultAsync(x=> x.Id == request.idWeek, cancellationToken);

        return week is null
            ? null
            : new WeekDTO(week.Id, week.StartWeek, week.Description);
    }
}