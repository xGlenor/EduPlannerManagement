namespace EduPlanner.Domain.Entities.Weeks;

public class WeekWeekType
{
    public int? WeekId { get; set; }
    public int? WeekTypeId { get; set; }
    
    public virtual Week? Week { get; set; }
    public virtual WeekType? WeekType { get; set; }
}