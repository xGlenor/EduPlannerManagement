using EduPlanner.Application.CourseTimes;
using EduPlanner.Application.Reservations;

namespace EduPlanner.Application.Teachers;

public record TeacherTimesDTO(IEnumerable<CourseTimeDTO> Courses, IEnumerable<ReservationDTO> Reservations);