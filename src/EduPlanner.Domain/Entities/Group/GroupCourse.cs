namespace EduPlanner.Domain.Entities;

public class GroupCourse
{
    public int GroupId { get; set; }
    public Group Group { get; set; }
    
    public int CourseId { get; set; }
    public Course Course { get; set; }
}