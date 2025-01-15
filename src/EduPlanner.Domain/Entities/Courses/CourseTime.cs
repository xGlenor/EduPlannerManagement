
using EduPlanner.Domain.Entities.Rooms;
using EduPlanner.Domain.Entities.Weeks;

namespace EduPlanner.Domain.Entities.Courses;

public class CourseTime
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public int WeekId { get; set; }
    public Week Week { get; set; }
    
    public int WeekTypeId { get; set; }
    public WeekType WeekType { get; set; }
    
    public int RoomId { get; set; }
    public Room Room { get; set; }
    
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public static string OldTable = "times";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "idEvent",
        "start",
        "dur",
        "idWeek",
        "idWeekDef",
        "dtStart",
        "dtStop",
        "idRoom",
    };
    
}