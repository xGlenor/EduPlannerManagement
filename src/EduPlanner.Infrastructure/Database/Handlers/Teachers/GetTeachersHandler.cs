using MediatR;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Teachers;
using EduPlanner.Domain.Entities.Teachers;

namespace EduPlanner.Infrastructure.Database.Handlers.Teachers;

internal class GetTeachersHandler(NewDbContext dbContext) : IRequestHandler<GetTeachers, IEnumerable<TeacherDTO>>
{
    public async Task<IEnumerable<TeacherDTO>> Handle(GetTeachers request, CancellationToken cancellationToken)
    {
        var trimmedName = request.Name.Trim();
        
        var teachers = await dbContext
            .Teachers
            .Where(t => t.Name.Contains(trimmedName) || t.Surname.Contains(trimmedName))
            .ToListAsync(cancellationToken);
        
        return teachers
            .Select(ToDTO)
            .ToArray();
    }
    
    private TeacherDTO ToDTO(Teacher teacher) => new TeacherDTO(teacher.Id, teacher.Name, teacher.Surname);
}