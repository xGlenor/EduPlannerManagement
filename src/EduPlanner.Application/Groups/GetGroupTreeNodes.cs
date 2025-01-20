using MediatR;
using EduPlanner.Application.Tree;

namespace EduPlanner.Application.Groups;

public record GetGroupTreeNodes(int ParentId) : IRequest<TreeNodesDTO<GroupDTO>>;