using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Groups;

public class GroupCourse
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public static string OldTable = "set_groups";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "id_group",
    };
}