using MediatR;
using EduPlanner.Application.Common;

namespace EduPlanner.Application.Rooms;

public record GetRoomTreeNodes(int ParentId) : IRequest<TreeNodesDTO<RoomDTO>>;