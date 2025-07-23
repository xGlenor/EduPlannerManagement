using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Rooms;

public class RoomCourse
{
    public int? CourseId { get; set; }
    public int? RoomId { get; set; }
    
    public virtual Course? Course { get; set; }
    public virtual Room? Room { get; set; }
}