using MediatR;
using EduPlanner.Application.Tree;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Teachers;
using EduPlanner.Domain.Entities.Teachers;

namespace EduPlanner.Infrastructure.Database.Handlers.Teachers;

internal class GetTeacherTreeNodesHandler(NewDbContext dbContext)
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
                new TreeNodeDTO<TeacherDTO>(
                    x.Id, 
                    x.Name, 
                    x.ShowPlan, 
                    GroupsFor(x.Id, request.ParentId),
                    dbContext.TeacherTrees.Any(z => z.ParentId == x.Id)
                )
            )
            .ToList();
        
         return new TreeNodesDTO<TeacherDTO>(nodes);
    }

    private TeacherDTO ToDTO(Teacher teacher) => new TeacherDTO(teacher.Id, teacher.Name, teacher.Surname);

    private IEnumerable<TeacherDTO> GroupsFor(int Id, int ParentId)
    {
        return ParentId == 0
            ? dbContext.Teachers
                .Where(y => y.TeacherTreeId == Id || y.TeacherTreeId == 0)
                .Select(ToDTO)
            : dbContext.Teachers
                .Where(y => y.TeacherTreeId == Id)
                .Select(ToDTO);
    }
    
}