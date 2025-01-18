using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Common;
using EduPlanner.Application.Groups;
using EduPlanner.Domain.Entities.Groups;

namespace EduPlanner.Infrastructure.Database.Handlers.Courses;

public class GetGroupTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetGroupTreeNodes, TreeNodesDTO<GroupDTO>>
{
    public async Task<TreeNodesDTO<GroupDTO>> Handle(GetGroupTreeNodes request, CancellationToken cancellationToken)
    {
        var groupNodes = await dbContext
            .GroupTrees
            .Where(x => x.ParentId == request.ParentId)
            .ToListAsync(cancellationToken: cancellationToken);

        var nodes = groupNodes
            .Select(x =>
            {
                var groups = dbContext
                    .Groups
                    .Where(y => y.GroupTreeId == x.Id)
                    .ToArray();
                return new TreeNodeDTO<GroupDTO>(x.Id, x.Name, x.ShowPlan, groups.Select(ToGroupDTO));
            })
            .ToList();

         return new TreeNodesDTO<GroupDTO>(nodes);
    }

    private GroupDTO ToGroupDTO(Group group) => new GroupDTO(group.Id, group.Name, group.Shortcut);
}