using MediatR;

namespace EduPlanner.Application.Teachers;

public record GetTeachers(string Name) : IRequest<IEnumerable<TeacherDTO>>;