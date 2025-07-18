using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

public class GroupTree: IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool? ShowPlan { get; set; }
    public int? ParentId { get; set; }
    
    public static ICollection<string> OldFields = new List<string>()
    {
        //Todo Analiza
        "iTimeRangeStart",
        "iTimeRangeStop",
        "bTimeRangeActive",
    };
}