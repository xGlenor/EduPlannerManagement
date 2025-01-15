using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

public class Week: IEntity
{
    public int Id { get; set; }
    public DateTime? StartWeek { get; set; }
    public string? Description { get; set; }
    
    public ICollection<WeekWeekType>? WeekWeekTypes { get; set; }
    public ICollection<CourseTime>? CourseTimes { get; set; }
    
    public static string OldTable = "weeks";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "idWeek",
        "dtStart",
        "sDescript"
    };
}