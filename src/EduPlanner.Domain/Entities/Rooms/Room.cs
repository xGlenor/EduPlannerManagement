using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Rooms;

public class Room : IEntity
{
    public int Id { get; set; }
    public string? NrRoom { get; set; }
    public string? Type { get; set; }
    public string? Comment { get; set; }
    public short? Capacity { get; set; }
    public short? CapacityLab { get; set; }
    
    public int? RoomTreeId { get; set; }
}