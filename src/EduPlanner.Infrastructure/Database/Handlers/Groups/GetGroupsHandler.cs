using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Groups;
using EduPlanner.Domain.Entities.Groups;

namespace EduPlanner.Infrastructure.Database.Handlers.Groups;

public class GetGroupsHandler(NewDbContext dbContext) : IRequestHandler<GetGroups, IEnumerable<GroupDTO>>
{
    public async Task<IEnumerable<GroupDTO>> Handle(GetGroups request, CancellationToken cancellationToken)
    {
        var trimmedName = request.Name.Trim();

        var groups = await dbContext
            .Groups
            .Where(x => x.Name.Contains(trimmedName) || x.Shortcut.Contains(trimmedName))
            .ToListAsync(cancellationToken);

        return groups
            .Select(ToDTO)
            .ToArray();
    }
    
    private GroupDTO ToDTO(Group group) => new GroupDTO(group.Id, group.Name, group.Shortcut);
}