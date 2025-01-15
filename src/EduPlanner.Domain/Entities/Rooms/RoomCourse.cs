using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Rooms;

public class RoomCourse
{
    public int RoomId { get; set; }
    public Room Room { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public static string OldTable = "set_rooms";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "id_room",
    };
}