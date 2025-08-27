using MediatR;

namespace EduPlanner.Application.Groups;

public sealed record GetGroupTree(int? RootId = null) : IRequest<List<GroupTreeDto>>;