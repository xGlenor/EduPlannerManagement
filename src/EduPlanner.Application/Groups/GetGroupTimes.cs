using MediatR;

namespace EduPlanner.Application.Groups;

public record GetGroupTimes(int GroupId, int WeekId) : IRequest<GroupTimesDTO>;