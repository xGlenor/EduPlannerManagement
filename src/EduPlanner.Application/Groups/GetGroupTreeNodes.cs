using MediatR;
using EduPlanner.Application.Common;

namespace EduPlanner.Application.Groups;

public record GetGroupTreeNodes(int ParentId) : IRequest<TreeNodesDTO<GroupDTO>>;