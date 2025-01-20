using System.ComponentModel.DataAnnotations.Schema;
using EduPlanner.Domain.Entities.Courses;

namespace EduPlanner.Domain.Entities.Teachers;

[Table("set_cond")]
public class TeacherCourse
{
    [Column("id_cond")]
    public int TeacherId { get; set; }
    
    [Column("id")]
    public int CourseId { get; set; }
    
    [Column("remarks")]
    public string? Remarks { get; set; }
    
    [Column("idRoom")]
    public int? IdRoom { get; set; } 
    
}