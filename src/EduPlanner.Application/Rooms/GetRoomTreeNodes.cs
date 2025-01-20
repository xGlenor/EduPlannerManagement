using MediatR;
using EduPlanner.Application.Tree;

namespace EduPlanner.Application.Rooms;

public record GetRoomTreeNodes(int ParentId) : IRequest<TreeNodesDTO<RoomDTO>>;