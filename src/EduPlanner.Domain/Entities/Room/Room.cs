using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities;

public class Room : IEntity
{
    public int Id { get; set; }
    public string? NrRoom { get; set; }
    public string? Type { get; set; }
    public short? Capacity { get; set; }
    public short? CapacityLab { get; set; }
    
}