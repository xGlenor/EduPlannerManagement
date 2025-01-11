namespace EduPlanner.Domain.Entities;

public class WeekWeekType
{
    public int WeekId { get; set; }
    public Week Week { get; set; }
    
    public int WeekTypeId { get; set; }
    public WeekType WeekType { get; set; }

}