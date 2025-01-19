using EduPlanner.Application.Common;
using EduPlanner.Application.Groups;
using EduPlanner.Application.Tree;
using EduPlanner.Domain.Entities.Groups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Groups;

internal class GetGroupTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetGroupTreeNodes, TreeNodesDTO<GroupDTO>>
{
    public async Task<TreeNodesDTO<GroupDTO>> Handle(GetGroupTreeNodes request, CancellationToken cancellationToken)
    {
        // var groupNodes = await dbContext
        //     .GroupTrees
        //     .Include(x=>x.Groups)
        //     .Where(x => x.ParentId == request.ParentId)
        //     .ToListAsync(cancellationToken: cancellationToken);
        //
        // var nodes = groupNodes
        //     .Select(x => new TreeNodeDTO<GroupDTO>(x.Id, x.Name, x.ShowPlan, x.Groups.Select(ToGroupDTO)))
        //     .ToList();
        //
        //  return new TreeNodesDTO<GroupDTO>(nodes);

        return null;
    }

    private GroupDTO ToGroupDTO(Group group) => new GroupDTO(group.Id, group.Name, group.Shortcut);
}