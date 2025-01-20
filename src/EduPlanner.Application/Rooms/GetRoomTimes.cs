using MediatR;

namespace EduPlanner.Application.Rooms;

public record GetRoomTimes(int RoomId, int WeekId, int WeekTypeId) : IRequest<RoomTimesDTO>;