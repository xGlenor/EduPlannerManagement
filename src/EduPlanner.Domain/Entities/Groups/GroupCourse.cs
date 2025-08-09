using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Groups;

public class GroupCourse
{
    public int? CourseId { get; set; }
    public int? GroupId { get; set; }
    
    public virtual Course? Course { get; set; }
    public virtual Group? Group { get; set; }
}