using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Rooms;

public class RoomTree: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    public RoomTree? Parent { get; set; }
    public bool ShowPlan { get; set; }
    
    
    public ICollection<RoomTree>? Children { get; set; }
    public ICollection<Room>? Rooms { get; set; }
    
    public static string OldTable = "room_tree";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id_room_tree",
        "name",
        "parent",
        "iTimeRangeStart",
        "iTimeRangeStop",
        "bTimeRangeActive",
        "bShowPlan"
    };
    
}