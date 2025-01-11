namespace EduPlanner.Domain.Entities;

public class CourseTime
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public int WeekId { get; set; }
    public Week Week { get; set; }
    
    public int WeekTypeId { get; set; }
    public WeekType WeekType { get; set; }
    
}