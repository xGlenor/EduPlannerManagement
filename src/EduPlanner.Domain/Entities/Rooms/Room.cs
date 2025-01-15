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
    //public RoomTree? RoomTree { get; set; }
        
    public static string OldTable = "rooms";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id",
        "id_room_tree",
        "nr_room",
        "capacity",
        "comment",
        "type",
        "capacity_lab"
    };
}