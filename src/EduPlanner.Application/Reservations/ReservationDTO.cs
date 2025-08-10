using EduPlanner.Application.Rooms;
using EduPlanner.Application.Teachers;

namespace EduPlanner.Application.Reservations;

public record ReservationDTO(int Id, string Description, string Type, IEnumerable<RoomDTO> Rooms, IEnumerable<TeacherDTO> Teachers, DateTime? StartDate, DateTime? EndDate);