using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Application.Groups;

public record GroupTimesDTO(IEnumerable<CourseTimeDTO> Courses, IEnumerable<ReservationDTO> Reservations);