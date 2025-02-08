using MediatR;

namespace EduPlanner.Application.Teachers;

public record GetTeacherTimes(int TeacherId, int WeekId, int[] WeekTypeIds) : IRequest<TeacherTimesDTO>;