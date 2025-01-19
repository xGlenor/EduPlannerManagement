using EduPlanner.Application.Rooms;
using EduPlanner.Application.Groups;
using EduPlanner.Application.Teachers;

namespace EduPlanner.Application.CourseTimes;

public record CourseTimeDTO(int Id, IEnumerable<GroupDTO> Groups, IEnumerable<RoomDTO> Rooms, IEnumerable<TeacherDTO> Teachers, CourseDTO Course, int MinutesStart, int MinutesEnd, DateTime? StartDate, DateTime? EndDate);