using MediatR;
using EduPlanner.Application.Weeks;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Domain.Entities.Weeks;

namespace EduPlanner.Infrastructure.Database.Handlers.Weeks;

internal class GetWeeksHandler(NewDbContext dbContext) : IRequestHandler<GetWeeks, IEnumerable<WeekDTO>>
{
    public async Task<IEnumerable<WeekDTO>> Handle(GetWeeks request, CancellationToken cancellationToken)
    {
        var weekTypes = await dbContext
            .Weeks
            .ToListAsync();
        
        return weekTypes
            .Select(ToWeekTO);
    }
    
    private WeekDTO ToWeekTO(Week weekType) 
        => new WeekDTO(weekType.Id, weekType.StartWeek, weekType.Description);
}