using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class WeekType: IEntity
{
    public int Id { get; set; }
    public string Shortcut { get; set; }
    public string Description { get; set; }
    
    public ICollection<WeekWeekType>? WeekWeekTypes { get; set; }
}