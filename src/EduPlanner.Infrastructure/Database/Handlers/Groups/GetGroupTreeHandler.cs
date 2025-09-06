using EduPlanner.Application.Groups;
using EduPlanner.Application.Tree;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Groups;

public class GetGroupTreeHandler(NewDbContext dbContext): IRequestHandler<GetGroupTree, List<TreeDTO<GroupDTO>>>
{
    public async Task<List<TreeDTO<GroupDTO>>> Handle(GetGroupTree request, CancellationToken ct)
    {
        var nodes = await dbContext.GroupTrees
            .AsNoTracking()
            .OrderBy(t => t.Name ?? "") 
            .Select(t => new TreeItem(
                t.Id,
                t.Name ?? "",
                t.ParentId == 0 ? (int?)null : t.ParentId))
            .ToListAsync(ct);
        
        var groupsRaw = await dbContext.Groups
            .AsNoTracking()
            .OrderBy(g => (g.Shortcut ?? g.Name) ?? "")     
            .Select(g => new { g.GroupTreeId, g.Id, g.Name, g.Shortcut })
            .ToListAsync(ct);
        
        var children = nodes.ToLookup(n => n.ParentId);

        var groupsByTree = groupsRaw.ToLookup(
            x => x.GroupTreeId,
            x => new GroupDTO(x.Id, x.Name ?? "", x.Shortcut ?? "")
        );
        
        TreeDTO<GroupDTO> Build(TreeItem n) => new(
            n.Id,
            n.Name,
            children[n.Id].Select(Build).ToList(),
            groupsByTree[n.Id].ToList()
        );

        var roots = request.RootId is int rid
            ? nodes.Where(n => n.Id == rid)
            : children[default(int?)];

        return roots.Select(Build).ToList();
    }
}
