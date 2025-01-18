using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Common;
using EduPlanner.Application.Teachers;
using EduPlanner.Domain.Entities.Teachers;

namespace EduPlanner.Infrastructure.Database.Handlers.Courses;

public class GetTeacherTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetTeacherTreeNodes, TreeNodesDTO<TeacherDTO>>
{
    public async Task<TreeNodesDTO<TeacherDTO>> Handle(GetTeacherTreeNodes request, CancellationToken cancellationToken)
    {
        var teacherNodes = await dbContext
            .TeacherTrees
            .Where(x => x.ParentId == request.ParentId)
            .ToListAsync(cancellationToken: cancellationToken);

        var nodes = teacherNodes
            .Select(x =>
            {
                var teachers = dbContext
                    .Teachers
                    .Where(y => y.TeacherTreeId == x.Id)
                    .ToArray();
                return new TreeNodeDTO<TeacherDTO>(x.Id, x.Name, x.ShowPlan, teachers.Select(ToTeacherDTO));
            })
            .ToList();

         return new TreeNodesDTO<TeacherDTO>(nodes);
    }

    private TeacherDTO ToTeacherDTO(Teacher teacher) => new TeacherDTO(teacher.Id, teacher.Name, teacher.Surname);
}