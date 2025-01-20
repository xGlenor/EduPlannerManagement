using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Reservations;
using EduPlanner.Domain.Interfaces;

namespace EduPlanner.Domain.Entities.Teachers;

[Table("conductors")]
public class Teacher: IEntity
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("surname")]
    public string? Surname { get; set; }
    [Column("shortcut")]
    public string? Shortcut { get; set; }
    [Column("title")]
    public string? Title { get; set; }
    [Column("room")]
    public string? Room { get; set; }
    [Column("mail")]
    public string? Mail { get; set; }
    [Column("phone")]
    public string? Phone { get; set; }
    
    [Column("id_cond_tree")]
    public int? TeacherTreeId { get; set; }
    
}
