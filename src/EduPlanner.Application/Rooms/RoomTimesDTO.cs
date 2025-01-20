using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Application.Rooms;

public record RoomTimesDTO(IEnumerable<CourseTimeDTO> Courses, IEnumerable<ReservationDTO> Reservations);