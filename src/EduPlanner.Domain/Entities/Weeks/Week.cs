using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Weeks;

public class Week: IEntity
{
    public int Id { get; set; }
    public DateTime? StartWeek { get; set; }
    public string? Description { get; set; }
}