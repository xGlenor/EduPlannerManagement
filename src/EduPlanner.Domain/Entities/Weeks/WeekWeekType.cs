namespace EduPlanner.Domain.Entities.Weeks;

public class WeekWeekType
{
    public int WeekId { get; set; }
    public Week Week { get; set; }
    
    public int WeekTypeId { get; set; }
    public WeekType WeekType { get; set; }
    
    public static string OldTable = "weekweekdef";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "idWeek",
        "idWeekDef",
    };

}