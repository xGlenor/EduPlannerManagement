using MediatR;

namespace EduPlanner.Application.Rooms;

public record GetRooms(string Nr) : IRequest<IEnumerable<RoomDTO>>;