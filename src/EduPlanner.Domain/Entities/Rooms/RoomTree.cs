using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Rooms;

public class RoomTree: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    public bool? ShowPlan { get; set; }
}