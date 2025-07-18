using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

public class WeekType: IEntity
{
    public int Id { get; set; }
    public string? Shortcut { get; set; }
    public string? Description { get; set; }
    public bool? Show {get; set;}
}