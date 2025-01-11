using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class RoomTree: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    
    public int? ParentId { get; set; }
    public RoomTree Parent { get; set; }
    public ICollection<RoomTree> Children { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
    
}