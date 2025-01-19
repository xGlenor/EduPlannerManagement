using MediatR;

namespace EduPlanner.Application.Groups;

public record GetGroups(string Name) : IRequest<IEnumerable<GroupDTO>>;