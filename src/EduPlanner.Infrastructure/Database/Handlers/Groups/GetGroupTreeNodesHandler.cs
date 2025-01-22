using MediatR;
using EduPlanner.Application.Tree;
using EduPlanner.Application.Groups;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Domain.Entities.Groups;

namespace EduPlanner.Infrastructure.Database.Handlers.Groups;

internal class GetGroupTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetGroupTreeNodes, TreeNodesDTO<GroupDTO>>
{
    public async Task<TreeNodesDTO<GroupDTO>> Handle(GetGroupTreeNodes request, CancellationToken cancellationToken)
    {
        var groupNodes =
            await dbContext
                .GroupTrees
                .Where(x => x.ParentId == request.ParentId)
                .ToListAsync(cancellationToken: cancellationToken);
        
        var nodes = groupNodes
            .Select(x => 
                new TreeNodeDTO<GroupDTO>(
                    x.Id, 
                    x.Name, 
                    x.ShowPlan, 
                    dbContext.Groups.Where(y=>y.GroupTreeId == x.Id).AsEnumerable().Select(ToDTO),
                    dbContext.GroupTrees.Any(z => z.ParentId == x.Id)
                )
            )
            .ToList();
        
         return new TreeNodesDTO<GroupDTO>(nodes);

        return null;
    }

    private GroupDTO ToDTO(Group group) => new GroupDTO(group.Id, group.Name, group.Shortcut);
}