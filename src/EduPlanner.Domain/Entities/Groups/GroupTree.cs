using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Groups;

[Table("group_tree")]
public class GroupTree: IEntity
{
    [Column("id_group_tree")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("bShowPlan")]
    public bool? ShowPlan { get; set; }
    
    [Column("parent")]
    public int? ParentId { get; set; }
    
    public static ICollection<string> OldFields = new List<string>()
    {
        //Todo Analiza
        "iTimeRangeStart",
        "iTimeRangeStop",
        "bTimeRangeActive",
    };
}