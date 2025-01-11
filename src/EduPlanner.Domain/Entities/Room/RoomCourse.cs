namespace EduPlanner.Domain.Entities;

public class RoomCourse
{
    public int RoomId { get; set; }
    public Room Room { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}