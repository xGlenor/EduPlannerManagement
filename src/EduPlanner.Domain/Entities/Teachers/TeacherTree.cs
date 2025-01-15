using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Teachers;

public class TeacherTree: IEntity
{
    [Column("TeacherID")]
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public TeacherTree? Parent { get; set; }
    public bool ShowPlan { get; set; }
    
    public ICollection<TeacherTree>? Children { get; set; }
    public ICollection<Teacher>? Teachers { get; set; }
    
    public static string OldTable = "cond_tree";
    
    public static ICollection<string> OldFields = new List<string>()
    {
        "id_cond_tree",
        "name",
        "parent",
        "iTimeRangeStart",
        "iTimeRangeStop",
        "bTimeRangeActive",
        "bShowPlan"
    };

}