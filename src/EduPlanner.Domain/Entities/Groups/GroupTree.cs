using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

public class GroupTree: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool ShowPlan { get; set; }
    
    public int? ParentId { get; set; }
    public GroupTree? Parent { get; set; }
    
    public ICollection<GroupTree>? Children { get; set; }
    public ICollection<Group>? Groups { get; set; }
    
    public static string OldTable = "group_tree";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id_group_tree",
        "name",
        "parent",
        //Todo Analiza
        "iTimeRangeStart",
        "iTimeRangeStop",
        "bTimeRangeActive",
        "bShowPlan"
    };
}