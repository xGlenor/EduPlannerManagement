using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Teachers;

[Table("cond_tree")]
public class TeacherTree: IEntity
{
    [Column("id_cond_tree")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("parent")]
    public int? ParentId { get; set; }
    
    [Column("bShowPlan")]
    public bool? ShowPlan { get; set; }
    
}