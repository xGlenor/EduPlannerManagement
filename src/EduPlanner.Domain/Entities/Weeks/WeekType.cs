
using EduPlanner.Domain.Entities.Courses;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

public class WeekType: IEntity
{
    public int Id { get; set; }
    public string? Shortcut { get; set; }
    public string? Description { get; set; }
    public bool? Show {get; set;}
    
    public ICollection<WeekWeekType>? WeekWeekTypes { get; set; }
    public ICollection<CourseTime>? CourseTimes { get; set; }
    
    public static string OldTable = "weekdefs";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "idWeekDef",
        "sShortcut",
        "sDescript",
        "bShow",
    };

}