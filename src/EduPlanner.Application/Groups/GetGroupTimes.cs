using MediatR;

namespace EduPlanner.Application.Groups;

public record GetGroupTimes(int GroupId, int WeekId, int[] WeekTypeIds) : IRequest<GroupTimesDTO>;