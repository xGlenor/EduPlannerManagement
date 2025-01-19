using EduPlanner.Application.Common;
using EduPlanner.Application.Teachers;
using EduPlanner.Application.Tree;
using EduPlanner.Domain.Entities.Teachers;
using MediatR;

namespace EduPlanner.Infrastructure.Database.Handlers.Teachers;

internal class GetTeacherTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetTeacherTreeNodes, TreeNodesDTO<TeacherDTO>>
{
    public async Task<TreeNodesDTO<TeacherDTO>> Handle(GetTeacherTreeNodes request, CancellationToken cancellationToken)
    {
        // var teacherNodes = await dbContext
        //     .TeacherTrees
        //     .Include(x=>x.Teachers)
        //     .Where(x => x.ParentId == request.ParentId)
        //     .ToListAsync(cancellationToken: cancellationToken);
        //
        // var nodes = teacherNodes
        //     .Select(x => new TreeNodeDTO<TeacherDTO>(x.Id, x.Name, x.ShowPlan, x.Teachers.Select(ToTeacherDTO)))
        //     .ToList();
        //
        //  return new TreeNodesDTO<TeacherDTO>(nodes);
        return null;
    }

    private TeacherDTO ToTeacherDTO(Teacher teacher) => new TeacherDTO(teacher.Id, teacher.Name, teacher.Surname);
}