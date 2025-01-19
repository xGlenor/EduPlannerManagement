using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Domain.Entities.Weeks;
using EduPlanner.Application.WeekTypes;

namespace EduPlanner.Infrastructure.Database.Handlers.WeekTypes;

internal class GetWeekTypesHandler(NewDbContext dbContext) : IRequestHandler<GetWeekTypes, IEnumerable<WeekTypeDTO>>
{
    public async Task<IEnumerable<WeekTypeDTO>> Handle(GetWeekTypes request, CancellationToken cancellationToken)
    {
        var weekTypes = await dbContext
            .WeekTypes
            .ToListAsync();
        
        return weekTypes
            .Select(ToWeekTypeDTO);
    }
    
    private WeekTypeDTO ToWeekTypeDTO(WeekType weekType) 
        => new WeekTypeDTO(weekType.Id, weekType.Shortcut, weekType.Description, weekType.Show);
}