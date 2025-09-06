using EduPlanner.Application.Teachers;
using EduPlanner.Application.Tree;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Teachers;

public class GetTeacherTreeHandler(NewDbContext dbContext) : IRequestHandler<GetTeacherTree, List<TreeDTO<TeacherDTO>>>
{
    public async Task<List<TreeDTO<TeacherDTO>>> Handle(GetTeacherTree request, CancellationToken ct)
    {
        var nodes = await dbContext.TeacherTrees
            .AsNoTracking()
            .OrderBy(t => t.Name ?? "")
            .Select(t => new TreeItem(
                t.Id,
                t.Name ?? "",
                t.ParentId == 0 ? (int?)null : t.ParentId))
            .ToListAsync(ct);
        
        var teachersRaw = await dbContext.Teachers
            .AsNoTracking()
            .OrderBy(t => (t.Shortcut ?? t.Name) ?? "")
            .Select(t => new { t.TeacherTreeId, t.Id, t.FullNameWithTitle, t.Shortcut })
            .ToListAsync(ct);
        
        var children = nodes.ToLookup(t => t.ParentId);

        var teachersByTree = teachersRaw.ToLookup(
            t => t.TeacherTreeId,
            t => new TeacherDTO(t.Id, t.FullNameWithTitle, t.Shortcut ?? "")
        );

        TreeDTO<TeacherDTO> Build(TreeItem t) => new(
            t.Id,
            t.Name,
            children[t.Id].Select(Build).ToList(),
            teachersByTree[t.Id].ToList()
            );
        
        var roots = request.RootId is int rid
            ? nodes.Where(n => n.Id == rid)
            : children[default(int?)];

        return roots.Select(Build).ToList();
    }
}