using EduPlanner.Domain.Entities.Groups;
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Teachers;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Courses;


public class Course: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Shortcut { get; set; }
    public string? TypeCourse { get; set; }
    public string? Comment { get; set; }
    
    public ICollection<GroupCourse>? GroupCourse { get; set; }
    public ICollection<TeacherCourse>? TeacherCourse { get; set; }
    public ICollection<RoomCourse>? RoomCourse { get; set; }
    
    public ICollection<CourseTime>? CourseTimes { get; set; }
    
    public static string OldTable = "courses";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "name",
        "shortcut",
        "type",
        "comment",
    };
    
}
